using FasTnT.Commands.Requests;
using FasTnT.Domain.Commands;
using FasTnT.Model.Queries;
using System.Linq;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Queries
{
    [XmlType("Poll", Namespace = "urn:epcglobal:epcis-query:xsd:1")]
    public class Poll : EpcisXmlQuery
    {
        [XmlElement(ElementName = "queryName", Namespace = "")]
        public string QueryName { get; set; }
        [XmlArray(ElementName = "params", Namespace = ""), XmlArrayItem(ElementName = "param", Namespace = default)]
        public PollParameter[] Parameters { get; set; }

        internal override IQueryRequest GetEpcisRequest()
        {
            var parameters = Parameters.Select(ToEpcisParameter).ToArray();

            return new PollRequest
            {
                QueryName = QueryName,
                Parameters = parameters
            };
        }

        private QueryParameter ToEpcisParameter(PollParameter parameter)
        {
            var values = string.IsNullOrEmpty(parameter.Value)
                ? parameter.Values
                : new[] { parameter.Value };

            return new QueryParameter
            {
                Name = parameter.Name,
                Values = values
            };
        }
    }
}
