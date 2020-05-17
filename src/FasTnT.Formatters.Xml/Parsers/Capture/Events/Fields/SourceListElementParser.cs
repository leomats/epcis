using FasTnT.Model.Enums;
using FasTnT.Model.Events;
using FasTnT.Parsers.Xml.Capture;
using System.Linq;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Parsers.Capture.Parsers
{
    public class SourceListElementParser : IRootEventElementParser
    {
        public bool CanParse(XName name) => name.LocalName == "sourceList" && string.IsNullOrEmpty(name.NamespaceName);

        public void Parse(XElement element, IEventBuilder builder)
        {
            var sources = ParseSources(element.Elements().ToArray());

            builder.AddSourceDestinations(sources);
        }

        private SourceDestination[] ParseSources(XElement[] elements)
        {
            var sources = new SourceDestination[elements.Length];

            for(var i=0; i<sources.Length; i++)
            {
                sources[i] = new SourceDestination
                {
                    Type = elements[i].Attribute("type").Value,
                    Id = elements[i].Value,
                    Direction = SourceDestinationType.Source
                };
            }

            return sources;
        }
    }
}
