using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Queries
{
    [XmlType("Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class SoapQueryBody
    {
        [XmlElement("GetQueryNames", typeof(GetQueryNames), Namespace = "urn:epcglobal:epcis-query:xsd:1")]
        [XmlElement("GetSubscriptionIDs", typeof(GetSubscriptionIds), Namespace = "urn:epcglobal:epcis-query:xsd:1")]
        [XmlElement("Poll", typeof(Poll), Namespace = "urn:epcglobal:epcis-query:xsd:1")]
        [XmlElement("GetVendorVersion", typeof(GetVendorVersion), Namespace = "urn:epcglobal:epcis-query:xsd:1")]
        [XmlElement("GetStandardVersion", typeof(GetStandardVersion), Namespace = "urn:epcglobal:epcis-query:xsd:1")]
        [XmlElement("Subscribe", typeof(Subscribe), Namespace = "urn:epcglobal:epcis-query:xsd:1")]
        [XmlElement("Unsubscribe", typeof(Unsubscribe), Namespace = "urn:epcglobal:epcis-query:xsd:1")]
        public EpcisXmlQuery Query { get; set; }
    }
}
