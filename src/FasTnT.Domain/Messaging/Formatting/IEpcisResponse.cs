using FasTnT.Domain.Commands;

namespace FasTnT.Commands.Responses
{
    public interface IEpcisResponse
    {
        void Accept(IResponseVisitor responseFormatter);
    }
}
