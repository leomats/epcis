using FasTnT.Model.Enums;
using FasTnT.Model.Events;
using FasTnT.Parsers.Xml.Capture;
using System.Linq;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Parsers.Capture.Parsers
{
    public class EpcListElementParser : IRootEventElementParser
    {
        public bool CanParse(XName name) => name.LocalName == "epcList" && string.IsNullOrEmpty(name.NamespaceName);

        public void Parse(XElement element, IEventBuilder builder)
        {
            var epcs = ParseEpcs(element.Elements().ToArray());

            builder.AddEpcs(epcs);
        }

        private Epc[] ParseEpcs(XElement[] elements)
        {
            var epcs = new Epc[elements.Length];

            for(var i=0; i<epcs.Length; i++)
            {
                epcs[i] = new Epc
                {
                    Id = elements[i].Value,
                    Type = EpcType.List
                };
            }

            return epcs;
        }
    }
}
