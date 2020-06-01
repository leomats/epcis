using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events.Quantity
{
    [XmlType("QuantityEvent")]
    public class QuantityEvent : BaseEpcisEvent
    {
        public string EpcClass { get; set; }
        public int Quantity { get; set; }
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
        public QuantityEventExtensionV1 Extension { get; set; }
        [XmlAnyElement]
        public XmlElement[] CustomFields { get; set; }
    }
}
