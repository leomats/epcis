using FasTnT.Commands.Responses;
using FasTnT.Formatters.Xml.Model.Queries;

namespace FasTnT.Formatters.Xml.Formatters
{
    public class XmlResponseFormatter : BaseResponseFormatter<XmlResponseDocument>
    {
        public override void Visit(ExceptionResponse response)
        {
            throw new System.NotImplementedException();
        }

        public override void Visit(GetQueryNamesResponse response)
        {
            throw new System.NotImplementedException();
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
