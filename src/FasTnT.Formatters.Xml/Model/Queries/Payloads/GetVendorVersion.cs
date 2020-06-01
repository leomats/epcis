using FasTnT.Commands.Requests;
using FasTnT.Domain.Commands;

namespace FasTnT.Formatters.Xml.Model.Queries
{
    public class GetVendorVersion : EpcisXmlQuery
    {
        internal override IQueryRequest GetEpcisRequest() => new GetVendorVersionRequest();
    }
}
