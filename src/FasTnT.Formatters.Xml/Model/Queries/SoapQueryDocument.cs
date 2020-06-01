using FasTnT.Domain.Commands;
using FasTnT.Parsers.Xml.Parsers.Query;
using System;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Queries
{
    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class SoapQueryDocument : IQueryRequestProvider
    {
        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public SoapQueryBody Body { get; set; }

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
