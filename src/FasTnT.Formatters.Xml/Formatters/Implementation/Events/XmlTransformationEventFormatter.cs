using FasTnT.Model.Enums;
using FasTnT.Model.Events;
using FasTnT.Parsers.Xml.Formatters.Implementation;
using FasTnT.Parsers.Xml.Utils;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Formatters.Events
{
    public class XmlTransformationEventFormatter : BaseV1_2EventFormatter
    {
        public XElement Process(EpcisEvent transformationEvent)
        {
            Root = XmlEventFormatter.CreateEvent("TransformationEvent", transformationEvent);

            AddInputOutputEpcList(transformationEvent);
            AddBusinessStep(transformationEvent);
            AddDisposition(transformationEvent);
            AddReadPoint(transformationEvent);
            AddBusinessLocation(transformationEvent);
            AddBusinessTransactions(transformationEvent);
            AddSourceDestinations(transformationEvent, Root);
            AddEventExtension(transformationEvent);
            AddIlmdFields(transformationEvent, Root);
            AddExtensionField();
            AddCustomFields(transformationEvent);

            return new XElement("extension", Root);
        }

        private void AddInputOutputEpcList(EpcisEvent evt)
        {
            var inputEpcList = new XElement("inputEPCList", XmlEventFormatter.FormatEpcList(evt, EpcType.InputEpc));
            var inputQuantity = new XElement("inputQuantityList", XmlEventFormatter.FormatEpcQuantity(evt, EpcType.InputQuantity));
            var outputQuantity = new XElement("outputQuantityList", XmlEventFormatter.FormatEpcQuantity(evt, EpcType.OutputQuantity));
            var outputEpcList = new XElement("outputEPCList", XmlEventFormatter.FormatEpcList(evt, EpcType.OutputEpc));

            Root.AddNotEmpties(inputEpcList, inputQuantity, outputEpcList, outputQuantity);
        }
    }
}