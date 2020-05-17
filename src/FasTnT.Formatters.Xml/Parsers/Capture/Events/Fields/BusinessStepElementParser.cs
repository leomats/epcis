using FasTnT.Parsers.Xml.Capture;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Parsers.Capture.Parsers
{
    public class BusinessStepElementParser : IRootEventElementParser
    {
        public bool CanParse(XName name) => name.LocalName == "bizStep" && string.IsNullOrEmpty(name.NamespaceName);

        public void Parse(XElement element, IEventBuilder builder)
        {
            var businessStep = element.Value;

            builder.SetBusinessStep(businessStep);
        }
    }
}
