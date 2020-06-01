using FasTnT.Domain.Commands;
using FasTnT.Parsers.Xml.Parsers.Query;
using System;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Queries
{
    [XmlRoot("EPCISQueryDocument", Namespace = "urn:epcglobal:epcis-query:xsd:1")]
    public class EpcisQueryDocument : IQueryRequestProvider
    {
        [XmlElement(ElementName = "EPCISBody", Namespace = "")]
        public EpcisQueryBody Body { get; set; }

        public IQueryRequest GetEpcisRequest()
        {
            if(Body == null)
            {
                throw new ArgumentException(nameof(Body));
            }
            if(Body.Query == null)
            {
                throw new ArgumentException(nameof(Body.Query));
            }

            return Body.Query.GetEpcisRequest();
        }
    }
}
