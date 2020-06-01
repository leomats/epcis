using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events.Transformation
{
    [XmlType("TransformationEvent")]
    public class TranformationEvent : BaseEpcisEvent
    {
        [XmlArray("inputEPCList"), XmlArrayItem("epc")]
        public List<Epc> InputEpcList { get; set; }
        [XmlArray("inputQuantityList"), XmlArrayItem("epc")]
        public List<Epc> InputQuantityList { get; set; }
        [XmlArray("OutputEPCList"), XmlArrayItem("epc")]
        public List<Epc> OutputEpcList { get; set; }
        [XmlArray("OutputQuantityList"), XmlArrayItem("epc")]
        public List<Epc> OutputQuantityList { get; set; }
        [XmlElement(ElementName = "transformationID")]
        public string TransformationId { get; set; }
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
        public TranformationEventExtensionV1 Extension { get; set; }
        [XmlAnyElement]
        public XmlElement[] CustomFields { get; set; }
    }
}
