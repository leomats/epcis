using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events
{
    public class ReadPoint
    {
        [XmlElement(ElementName = "id", IsNullable = false)]
        public string Id { get; set; }
        [XmlAnyElement]
        public XmlElement[] CustomFields { get; set; }
    }
}
