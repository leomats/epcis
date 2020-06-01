using FasTnT.Domain.Commands;

namespace FasTnT.Commands.Responses
{
    public class GetSubscriptionIdsResponse : IEpcisResponse
    {
        public string[] SubscriptionIds { get; set; }

        public void Accept(IResponseVisitor responseFormatter)
        {
            responseFormatter.Visit(this);
        }
    }
}
