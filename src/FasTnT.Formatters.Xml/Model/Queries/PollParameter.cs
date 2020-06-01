using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Queries
{
    public class PollParameter
    {
        [XmlElement(ElementName = "name")]
        public string Name { get; set; }
        [XmlElement(ElementName = "value")]
        public string Value { get; set; }
        [XmlArray(ElementName = "values"), XmlArrayItem(ElementName = "value")]
        public string[] Values { get; set; }
    }
}
