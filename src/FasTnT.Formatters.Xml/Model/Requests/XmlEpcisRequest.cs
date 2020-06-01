using FasTnT.Commands.Requests;
using FasTnT.Domain.Commands;
using FasTnT.Model;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events
{
    [XmlRoot("EPCISDocument", Namespace = "urn:epcglobal:epcis:xsd:1")]
    public class XmlEpcisRequest : ICaptureRequestProvider
    {
        // TODO: add EPCISHeader
        [XmlElement(ElementName = "EPCISBody", Namespace = "")]
        public XmlEventBody Body { get; set; }

        public ICaptureRequest GetEpcisCaptureRequest()
        {
            return new CaptureEpcisDocumentRequest
            {
                Request = new EpcisRequest
                {
                    EventList = null,// TODO
                }
            };
        }
    }
}
