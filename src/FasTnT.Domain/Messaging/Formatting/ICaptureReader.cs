using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FasTnT.Domain.Commands
{
    public interface ICaptureReader
    {
        Task<ICaptureRequest> ReadAsync(Stream input, CancellationToken cancellationToken);
    }
}
