using FasTnT.Parsers.Xml.Capture;
using System;
using System.Linq;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Parsers.Capture.Parsers
{
    public class BaseExtensionElementParser : IRootEventElementParser
    {
        private IBaseExtensionElementParser[] _parsers;

        public BaseExtensionElementParser(IBaseExtensionElementParser[] parsers)
        {
            _parsers = parsers ?? Array.Empty<IBaseExtensionElementParser>();
        }

        public bool CanParse(XName name) => name.LocalName == "baseExtension" && string.IsNullOrEmpty(name.NamespaceName);

        public void Parse(XElement element, IEventBuilder builder)
        {
            foreach(var childElement in element.Elements())
            {
                var parser = _parsers.FirstOrDefault(x => x.CanParse(childElement.Name));

                if(parser != null)
                {
                    parser.Parse(childElement, builder);
                }
            }
        }
    }
}
