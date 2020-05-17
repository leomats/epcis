using FasTnT.Model.Enums;
using FasTnT.Model.Events;
using FasTnT.Parsers.Xml.Capture;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Parsers.Capture.Parsers
{
    public class ParentIdElementParser : IRootEventElementParser
    {
        public bool CanParse(XName name) => name.LocalName == "parentID" && string.IsNullOrEmpty(name.NamespaceName);

        public void Parse(XElement element, IEventBuilder builder)
        {
            var parentId = new Epc
            {
                Id = element.Value,
                Type = EpcType.ParentId
            };

            builder.AddEpcs(parentId);
        }
    }
}
