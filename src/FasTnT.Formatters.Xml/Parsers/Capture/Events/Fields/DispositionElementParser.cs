using FasTnT.Parsers.Xml.Capture;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Parsers.Capture.Parsers
{
    public class DispositionElementParser : IRootEventElementParser
    {
        public bool CanParse(XName name) => name.LocalName == "disposition" && string.IsNullOrEmpty(name.NamespaceName);

        public void Parse(XElement element, IEventBuilder builder)
        {
            var disposition = element.Value;

            builder.SetDisposition(disposition);
        }
    }
}
