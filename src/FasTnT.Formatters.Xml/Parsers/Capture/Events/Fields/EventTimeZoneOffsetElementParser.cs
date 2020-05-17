using FasTnT.Model.Events;
using FasTnT.Parsers.Xml.Capture;
using System.Collections;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Parsers.Capture.Parsers
{
    public class EventTimeZoneOffsetElementParser : IRootEventElementParser
    {
        public bool CanParse(XName name) => name.LocalName == "eventTimeZoneOffset" && string.IsNullOrEmpty(name.NamespaceName);

        public void Parse(XElement element, IEventBuilder builder)
        {
            var eventTimeZoneOffset = new TimeZoneOffset
            {
                Representation = element.Value
            };

            builder.SetEventTimeZoneOffset(eventTimeZoneOffset);
        }
    }
}
