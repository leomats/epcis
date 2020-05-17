using FasTnT.Model.Enums;
using FasTnT.Model.Events;
using FasTnT.Parsers.Xml.Capture;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Parsers.Capture.Parsers
{
    public class ReadPointElementParser : IRootEventElementParser
    {
        public bool CanParse(XName name) => name.LocalName == "readPoint" && string.IsNullOrEmpty(name.NamespaceName);

        public void Parse(XElement element, IEventBuilder builder)
        {
            var readPoint = element.Element("id").Value;
            var extensionFields = ParseExtensions(element);

            builder.SetReadPoint(readPoint);
            builder.AddCustomFields(extensionFields);
        }

        private CustomField[] ParseExtensions(XElement element)
        {
            var fields = new List<CustomField>();
            var elements = element.Elements().Where(x => !string.IsNullOrEmpty(x.Name.NamespaceName));

            foreach(var customElement in elements)
            {
                var field = new CustomField
                {
                    Name = customElement.Name.LocalName,
                    Namespace = customElement.Name.NamespaceName,
                    Type = FieldType.ReadPointExtension
                };

                fields.Add(field);
            }

            return fields.ToArray();
        }
    }
}
