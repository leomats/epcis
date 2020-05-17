using FasTnT.Parsers.Xml.Capture;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Parsers.Capture.Parsers
{
    public class TransformationIdElementParser : IRootEventElementParser
    {
        public bool CanParse(XName name) => name.LocalName == "transformationId" && string.IsNullOrEmpty(name.NamespaceName);

        public void Parse(XElement element, IEventBuilder builder)
        {
            var transformationId = element.Value;

            builder.SetTransformationId(transformationId);
        }
    }
}
