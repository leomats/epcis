using FasTnT.Commands.Responses;
using FasTnT.Formatters.Xml.Model.Queries;

namespace FasTnT.Formatters.Xml.Formatters
{
    public class SoapResponseFormatter : BaseResponseFormatter<SoapQueryDocument>
    {
        public override SoapQueryDocument FormatResponse(IEpcisResponse response)
        {
            return new SoapQueryDocument
            {
                Body = new SoapQueryBody
                {
                    Query = GetBodyQuery()
                }
            };
        }

        private EpcisXmlQuery GetBodyQuery()
        {
            return new GetStandardVersion { };
        }
    }
}
