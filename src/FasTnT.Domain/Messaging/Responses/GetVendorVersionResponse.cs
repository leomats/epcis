using FasTnT.Domain.Commands;

namespace FasTnT.Commands.Responses
{
    public class GetVendorVersionResponse : IEpcisResponse
    {
        public string Version { get; set; }

        public void Accept(IResponseVisitor responseFormatter)
        {
            responseFormatter.Visit(this);
        }
    }
}
