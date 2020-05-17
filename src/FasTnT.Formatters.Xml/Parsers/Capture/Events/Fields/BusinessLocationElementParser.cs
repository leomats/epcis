using FasTnT.Parsers.Xml.Capture;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Parsers.Capture.Parsers
{
    public class BusinessLocationElementParser : IRootEventElementParser
    {
        public bool CanParse(XName name) => name.LocalName == "bizLocation" && string.IsNullOrEmpty(name.NamespaceName);

        public void Parse(XElement element, IEventBuilder builder)
        {
            var businessLocationId = element.Element("id").Value;
            // TODO: parse extension elements with conformance to EPCIS 1.0 and 1.1
            // (BusinessLocation extensions have been DEPRECATED in EPCIS 1.2)

            builder.SetBusinessLocation(businessLocationId);
        }
    }
}
