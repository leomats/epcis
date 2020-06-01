using FasTnT.Commands.Responses;
using FasTnT.Formatters.Xml.Model.Queries;
using FasTnT.Formatters.Xml.Model.Queries.Outbound;
using System.Linq;

namespace FasTnT.Formatters.Xml.Formatters
{
    public class SoapResponseFormatter : BaseResponseFormatter<SoapResponseDocument>
    {
        private void FormatSoapResponse(EpcisXmlResult response)
        {
            FormattedResponse = new SoapResponseDocument
            {
                Body = new SoapResponseBody { Result = response }
            };
        }

        public override void Visit(ExceptionResponse response)
        {
            throw new System.NotImplementedException();
        }

        public override void Visit(GetQueryNamesResponse response)
        {
            FormatSoapResponse(new GetQueryNamesResult { QueryNames = response.QueryNames.ToList() });
        }

        public override void Visit(GetStandardVersionResponse response)
        {
            throw new System.NotImplementedException();
        }

        public override void Visit(GetSubscriptionIdsResponse response)
        {
            throw new System.NotImplementedException();
        }

        public override void Visit(GetVendorVersionResponse response)
        {
            throw new System.NotImplementedException();
        }

        public override void Visit(PollResponse response)
        {
            throw new System.NotImplementedException();
        }

        public override void Visit(EmptyResponse response)
        {
            throw new System.NotImplementedException();
        }
    }
}
