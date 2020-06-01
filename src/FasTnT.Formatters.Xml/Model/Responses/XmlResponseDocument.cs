using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Queries
{
    [XmlRoot("EPCISQueryDocument", Namespace = "urn:epcglobal:epcis-query:xsd:1")]
    public class XmlResponseDocument
    {
        [XmlElement(ElementName = "EPCISBody", Namespace = "")]
        public XmlResponseBody Body { get; set; }
    }
}
