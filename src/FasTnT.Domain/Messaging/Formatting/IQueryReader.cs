using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FasTnT.Domain.Commands
{
    public interface IQueryReader
    {
        Task<IQueryRequest> ReadAsync(Stream input, CancellationToken cancellationToken);
    }
}
