using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events.Transaction
{
    [XmlType("TransactionEvent")]
    public class TransactionEvent : BaseEpcisEvent
    {
        [XmlArray("bizTransactionList"), XmlArrayItem("bizTransaction")]
        public List<BusinessTransaction> BusinessTransactions { get; set; }
        [XmlElement(ElementName = "parentID", IsNullable = false)]
        public string ParentId { get; set; }
        [XmlArray("epcList"), XmlArrayItem("epc")]
        public List<Epc> EpcList { get; set; }
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
        [XmlElement(ElementName = "extension")]
        public TransactionEventExtensionV1 Extension { get; set; }
        [XmlAnyElement]
        public XmlElement[] CustomFields { get; set; }
    }
}
