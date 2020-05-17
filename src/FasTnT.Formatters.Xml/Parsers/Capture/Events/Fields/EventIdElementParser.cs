using FasTnT.Parsers.Xml.Capture;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Parsers.Capture.Parsers
{
    public class EventIdElementParser : IRootEventElementParser
    {
        public bool CanParse(XName name) => name.LocalName == "eventID" && string.IsNullOrEmpty(name.NamespaceName);

        public void Parse(XElement element, IEventBuilder builder)
        {
            var eventId = element.Value;

            builder.SetEventId(eventId);
        }
    }
}
