using FasTnT.Formatters.Xml.Model.Queries.Outbound;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Queries
{
    [XmlType("EPCISBody")]
    public class XmlResponseBody
    {
        [XmlElement("GetQueryNamesResult", typeof(GetQueryNamesResult), Namespace = "urn:epcglobal:epcis-query:xsd:1")]
        [XmlElement("GetSubscriptionIDsResult", typeof(GetSubscriptionIdsResult), Namespace = "urn:epcglobal:epcis-query:xsd:1")]
        //[XmlElement("PollResult", typeof(Poll), Namespace = "urn:epcglobal:epcis-query:xsd:1")]
        //[XmlElement("GetVendorVersionResult", typeof(GetVendorVersion), Namespace = "urn:epcglobal:epcis-query:xsd:1")]
        //[XmlElement("GetStandardVersionResult", typeof(GetStandardVersion), Namespace = "urn:epcglobal:epcis-query:xsd:1")]
        //[XmlElement("SubscribeResult", typeof(Subscribe), Namespace = "urn:epcglobal:epcis-query:xsd:1")]
        //[XmlElement("UnsubscribeResult", typeof(Unsubscribe), Namespace = "urn:epcglobal:epcis-query:xsd:1")]
        public EpcisXmlResult Result { get; set; }
    }
}
