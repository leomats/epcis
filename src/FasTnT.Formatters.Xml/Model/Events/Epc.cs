using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events
{
    public class Epc
    {
        [XmlText]
        public string Value { get; set; }
    }
}
