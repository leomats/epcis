using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events
{
    public class BaseEpcisEventExtensionV1
    {
        [XmlElement(ElementName = "eventID")]
        public string EventId { get; set; }
        [XmlElement(ElementName = "errorDeclaration")]
        public ErrorDeclaration ErrorDeclaration { get; set; }
        [XmlElement(ElementName = "extension")]
        public ErrorDeclaration Extension { get; set; }
        [XmlAnyElement]
        public XElement[] CustomFields { get; set; }
    }
}
