using FasTnT.Commands.Responses;
using FasTnT.Formatters.Xml.Model.Queries;

namespace FasTnT.Formatters.Xml.Formatters
{
    public class XmlResponseFormatter : BaseResponseFormatter<XmlQueryDocument>
    {
        public override XmlQueryDocument FormatResponse(IEpcisResponse response)
        {
            return new XmlQueryDocument
            {
                Body = new XmlQueryBody
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
