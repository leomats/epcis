using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events.Object
{
    [XmlType("ObjectEvent")]
    public class ObjectEvent : BaseEpcisEvent
    {
        [XmlArray("epcList", IsNullable = false), XmlArrayItem("epc")]
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
        [XmlArray("bizTransactionList"), XmlArrayItem("bizTransaction")]
        public List<BusinessTransaction> BusinessTransactions { get; set; }
        [XmlElement(ElementName = "extension")]
        public ObjectEventExtensionV1 Extension { get; set; }
        [XmlAnyElement]
        public XmlElement[] CustomFields { get; set; }

        public bool ShouldSerializeBusinessStep() => !string.IsNullOrEmpty(BusinessStep);
    }
}
