using FasTnT.Domain.Commands;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FasTnT.Parsers.Xml.Parsers.Query
{
    public interface IQueryRequestProvider
    {
        IQueryRequest GetEpcisRequest();
    }
}
