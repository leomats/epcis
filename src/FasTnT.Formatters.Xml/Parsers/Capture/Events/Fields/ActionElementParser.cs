using FasTnT.Model.Enums;
using FasTnT.Model.Utils;
using FasTnT.Parsers.Xml.Capture;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Parsers.Capture.Parsers
{
    public class ActionElementParser : IRootEventElementParser
    {
        public bool CanParse(XName name) => name.LocalName == "action" && string.IsNullOrEmpty(name.NamespaceName);

        public void Parse(XElement element, IEventBuilder builder)
        {
            var action = Enumeration.GetByDisplayName<EventAction>(element.Value);

            builder.SetAction(action);
        }
    }
}
