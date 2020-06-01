using FasTnT.Commands.Requests;
using FasTnT.Domain.Commands;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Queries
{
    [XmlType("GetSubscriptionIDs", Namespace = "urn:epcglobal:epcis-query:xsd:1")]
    public class GetSubscriptionIds : EpcisXmlQuery
    {
        [XmlElement("queryName", Namespace = "")]
        public string QueryName { get; set; }

        internal override IQueryRequest GetEpcisRequest() => new GetSubscriptionIdsRequest { QueryName = QueryName };
    }
}
