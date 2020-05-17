using FasTnT.Model.Enums;
using FasTnT.Model.Events;
using FasTnT.Parsers.Xml.Capture;
using System.Linq;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Parsers.Capture.Parsers
{
    public class DestinationListElementParser : IRootEventElementParser
    {
        public bool CanParse(XName name) => name.LocalName == "destList" && string.IsNullOrEmpty(name.NamespaceName);

        public void Parse(XElement element, IEventBuilder builder)
        {
            var destinations = ParseDestinations(element.Elements().ToArray());

            builder.AddSourceDestinations(destinations);
        }

        private SourceDestination[] ParseDestinations(XElement[] elements)
        {
            var destinations = new SourceDestination[elements.Length];

            for(var i=0; i<destinations.Length; i++)
            {
                destinations[i] = new SourceDestination
                {
                    Type = elements[i].Attribute("type").Value,
                    Id = elements[i].Value,
                    Direction = SourceDestinationType.Destination
                };
            }

            return destinations;
        }
    }
}
