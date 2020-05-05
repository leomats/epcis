using FasTnT.Commands.Requests;
using FasTnT.Domain.Commands;
using FasTnT.Model;
using FasTnT.Model.Enums;
using FasTnT.Model.Utils;
using FasTnT.Parsers.Xml.Utils;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Xml.XPath;

namespace FasTnT.Parsers.Xml.Capture
{
    public class XmlRequestParser
    {
        private const string EventCallbackBodyPath = "EPCISBody/query:QueryResults/resultsBody/EventList";
        private const string EventCaptureBodyPath = "EPCISBody/EventList";
        private const string MasterdataBodyPath = "EPCISBody/VocabularyList";
        private const string MasterdataHeaderPath = "EPCISHeader/extension/EPCISMasterData/VocabularyList";

        public async Task<ICaptureRequest> Read(Stream input, CancellationToken cancellationToken)
        {
            EpcisRequest request;
            var document = await XmlDocumentParser.Instance.Parse(input, cancellationToken);

            if (document.Root.Name == XName.Get("EPCISQueryDocument", EpcisNamespaces.Query)) // Subscription callback result
            {
                request = ParseSubscriptionCallback(document);
            }
            else
            {
                request = ParseCaptureRequest(document);
            }

            return request != default 
                    ? new CaptureEpcisDocumentRequest {  Request = request }
                    : throw new Exception($"Document with root '{document.Root.Name}' is not expected here.");
        }

        private EpcisRequest ParseCaptureRequest(XDocument document)
        {
            var type = document.Root.Element("EPCISBody").Elements().First();

            switch (type.Name.LocalName)
            {
                case "VocabularyList":
                    return ParseRequest(document.Root, EventCaptureBodyPath, MasterdataBodyPath);
                case "EventList":
                    return ParseRequest(document.Root, EventCaptureBodyPath, MasterdataHeaderPath);
                default:
                    throw new Exception($"Element '{type.Name.LocalName}' not expected in this context.");
            }
        }

        private EpcisRequest ParseSubscriptionCallback(XDocument document)
        {
            var callback = document.Root.Element("EPCISBody").Elements().First();
            var request = ParseRequest(document.Root, EventCallbackBodyPath, MasterdataHeaderPath);

            request.SubscriptionCallback = ParseCallback(callback);

            return request ?? throw new Exception($"Document with root '{document.Root.Name}' not expected in this context.");
        }

        private EpcisRequest ParseRequest(XElement root, string eventRootPath, string masterdataRootPath)
        {
            return new EpcisRequest
            {
                StandardBusinessHeader = XmlHeaderParser.Parse(root.XPathSelectElement("EPCISHeader/sbdh:StandardBusinessDocumentHeader", EpcisNamespaces.Manager)),
                DocumentTime = DateTime.Parse(root.Attribute("creationDate").Value, CultureInfo.InvariantCulture),
                SchemaVersion = root.Attribute("schemaVersion").Value,
                CustomFields = XmlCustomFieldParser.ParseCustomFields(root.XPathSelectElement("EPCISHeader"), FieldType.HeaderExtension),
                EventList = XmlEventsParser.ParseEvents(root.XPathSelectElement(eventRootPath, EpcisNamespaces.Manager)?.Elements()?.ToArray() ?? Array.Empty<XElement>()),
                MasterdataList = XmlMasterDataParser.ParseMasterDatas(root.XPathSelectElement(masterdataRootPath, EpcisNamespaces.Manager)?.Elements("Vocabulary") ?? Array.Empty<XElement>())
            };
        }

        private SubscriptionCallback ParseCallback(XElement callbackElement)
        {
            return new SubscriptionCallback
            {
                SubscriptionId = callbackElement.Element("subscriptionID").Value,
                Reason = callbackElement.Element("reason")?.Value,
                CallbackType = Enumeration.GetByDisplayNameInvariant<QueryCallbackType>(callbackElement.Name.LocalName),
            };
        }
    }
}
