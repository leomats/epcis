using FasTnT.Commands.Requests;
using FasTnT.Domain.Commands;

namespace FasTnT.Formatters.Xml.Model.Queries
{
    public class GetStandardVersion : EpcisXmlQuery
    {
        internal override IQueryRequest GetEpcisRequest() => new GetStandardVersionRequest();
    }
}
