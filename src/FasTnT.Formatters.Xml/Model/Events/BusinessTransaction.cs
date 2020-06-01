using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events
{
    public class BusinessTransaction
    {
        [XmlAttribute(AttributeName ="type")]
        public string Type { get; set; }
        [XmlText]
        public string Id { get; set; }
    }
}
