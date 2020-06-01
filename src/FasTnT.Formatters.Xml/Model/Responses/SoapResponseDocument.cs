using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Queries
{
    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class SoapResponseDocument
    {
        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public SoapResponseBody Body { get; set; }
    }
}
