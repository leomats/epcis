using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using FasTnT.Model.Events;

namespace FasTnT.Parsers.Xml.Capture
{
    public class XmlEventsParser
    {
        private readonly IRootEventParser[] _eventParsers;

        public XmlEventsParser(IRootEventParser[] eventParsers)
        {
            _eventParsers = eventParsers;
        }

        internal List<EpcisEvent> ParseEvents(params XElement[] eventList)
        {
            return eventList.Select(ParseEvent).ToList();
        }

        private EpcisEvent ParseEvent(XElement xElement)
        {
            var result = default(EpcisEvent);
            var parser = _eventParsers.FirstOrDefault(x => x.CanParse(xElement.Name));

            if(parser != null)
            {
                result = parser.Parse(xElement);
            }

            return result;
        }
    }
}
