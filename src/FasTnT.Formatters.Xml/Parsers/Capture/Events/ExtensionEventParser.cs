using System.Xml.Linq;
using FasTnT.Model.Events;
using System.Linq;

namespace FasTnT.Parsers.Xml.Capture
{
    public class ExtensionEventParser : IRootEventParser
    {
        private readonly IExtensionEventParser[] _parsers;

        public ExtensionEventParser(IExtensionEventParser[] parsers)
        {
            _parsers = parsers;
        }

        public bool CanParse(XName name) => name.LocalName == "extension" && string.IsNullOrEmpty(name.NamespaceName);

        // Events in <extension> elements should be unique. If multiple events are in the request,
        // there should be one <extension> element for each event in the XML
        public EpcisEvent Parse(XElement element)
        {
            var eventElement = element.Elements().SingleOrDefault();
            var epcisEvent = default(EpcisEvent);

            var parser = _parsers.FirstOrDefault(x => x.CanParse(eventElement.Name));

            if(parser != null)
            {
                epcisEvent = parser.Parse(eventElement);
            }

            return epcisEvent;
        }
    }
}
