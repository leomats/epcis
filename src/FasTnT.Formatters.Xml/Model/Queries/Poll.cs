using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Queries
{
    [XmlType("Poll", Namespace = "urn:epcglobal:epcis-query:xsd:1")]
    public class Poll : EpcisXmlQuery
    {
        [XmlElement(ElementName = "queryName", Namespace = "")]
        public string QueryName { get; set; }
        [XmlArray(ElementName = "params", Namespace = ""), XmlArrayItem(ElementName = "param", Namespace = default)]
        public PollParameter[] Parameters { get; set; }
    }
}
