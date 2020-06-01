using FasTnT.Commands.Responses;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FasTnT.Domain.Commands
{
    public interface IResponseFormatter
    {
        Task FormatAsync(IEpcisResponse epcisResponse, Stream body, CancellationToken cancellationToken);
    }

    public interface IResponseVisitor
    {
        void Visit(EmptyResponse response);
        void Visit(ExceptionResponse response);
        void Visit(GetQueryNamesResponse response);
        void Visit(GetStandardVersionResponse response);
        void Visit(GetSubscriptionIdsResponse response);
        void Visit(GetVendorVersionResponse response);
        void Visit(PollResponse response);
    }
}
