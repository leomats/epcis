using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events.Object
{
    public class ObjectEventExtensionV2
    {
        [XmlAnyElement]
        public XmlElement[] CustomFields { get; set; }
    }
}
