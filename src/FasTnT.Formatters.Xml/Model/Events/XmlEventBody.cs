using FasTnT.Commands.Requests;
using FasTnT.Domain.Commands;
using FasTnT.Formatters.Xml.Model.Events.Aggregation;
using FasTnT.Formatters.Xml.Model.Events.Object;
using FasTnT.Formatters.Xml.Model.Events.Quantity;
using FasTnT.Formatters.Xml.Model.Events.Transaction;
using FasTnT.Model;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events
{
    [XmlRoot("EPCISDocument", Namespace = "urn:epcglobal:epcis:xsd:1")]
    public class XmlEpcisRequest
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

    public class XmlEventBody
    {
        // TODO: add EventListExtensionType
        [XmlArray("EventList")]
        [XmlArrayItem("ObjectEvent", typeof(ObjectEvent))]
        [XmlArrayItem("QuantityEvent", typeof(QuantityEvent))]
        [XmlArrayItem("TransactionEvent", typeof(TransactionEvent))]
        [XmlArrayItem("AggregationEvent", typeof(AggregationEvent))]
        public List<BaseEpcisEvent> EventList { get; set; }
    }
}
