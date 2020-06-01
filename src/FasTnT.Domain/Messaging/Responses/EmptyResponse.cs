using FasTnT.Domain.Commands;

namespace FasTnT.Commands.Responses
{
    public class EmptyResponse : IEpcisResponse
    {
        public static IEpcisResponse Value = new EmptyResponse();

        public void Accept(IResponseVisitor responseFormatter)
        {
            responseFormatter.Visit(this);
        }
    }
}
