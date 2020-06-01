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
}
