using System.Collections.Generic;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Queries.Outbound
{
    public class GetSubscriptionIdsResult : EpcisXmlResult
    {
        [XmlElement("SubscriptionID")]
        public List<string> SubscriptionIds { get; set; }
    }
}
