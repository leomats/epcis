using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events.Aggregation
{
    [XmlType("AggregationEvent")]
    public class AggregationEvent : BaseEpcisEvent
    {
        [XmlElement(ElementName = "parentID", IsNullable = false)]
        public string ParentId { get; set; }
        [XmlArray("childEPCs"), XmlArrayItem("epc")]
        public List<Epc> Children { get; set; }
        [XmlElement(ElementName = "action")]
        public string Action { get; set; }
        [XmlElement(ElementName = "bizStep")]
        public string BusinessStep { get; set; }
        [XmlElement(ElementName = "disposition")]
        public string Disposition { get; set; }
        [XmlElement(ElementName = "readPoint")]
        public ReadPoint ReadPoint { get; set; }
        [XmlElement(ElementName = "bizLocation")]
        public string BusinessLocation { get; set; }
        [XmlArray("bizTransactionList"), XmlArrayItem("bizTransaction")]
        public List<BusinessTransaction> BusinessTransactions { get; set; }
        [XmlElement(ElementName = "extension")]
        public AggregationEventExtensionV1 Extension { get; set; }
        [XmlAnyElement]
        public XmlElement[] CustomFields { get; set; }
    }
}
