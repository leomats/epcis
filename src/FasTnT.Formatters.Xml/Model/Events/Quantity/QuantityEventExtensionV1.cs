using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events.Quantity
{
    public class QuantityEventExtensionV1
    {
        [XmlAnyElement]
        public XmlElement[] CustomFields { get; set; }
    }
}
