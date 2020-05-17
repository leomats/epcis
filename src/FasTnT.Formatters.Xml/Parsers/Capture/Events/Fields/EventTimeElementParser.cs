using FasTnT.Parsers.Xml.Capture;
using System;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Parsers.Capture.Parsers
{
    public class EventTimeElementParser : IRootEventElementParser
    {
        public bool CanParse(XName name) => name.LocalName == "eventTime" && string.IsNullOrEmpty(name.NamespaceName);

        public void Parse(XElement element, IEventBuilder builder)
        {
            var eventTime = DateTime.Parse(element.Value);

            builder.SetEventTime(eventTime);
        }
    }
}
