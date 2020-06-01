using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events.Aggregation
{
    public class AggregationEventExtensionV2
    {
        [XmlAnyElement]
        public XmlElement[] CustomFields { get; set; }
    }
}
