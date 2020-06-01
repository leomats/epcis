using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events.Transformation
{
    public class TranformationEventExtensionV1
    {
        [XmlAnyElement]
        public XmlElement[] CustomFields { get; set; }
    }
}
