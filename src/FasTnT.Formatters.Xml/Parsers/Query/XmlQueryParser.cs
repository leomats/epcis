using FasTnT.Domain.Commands;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FasTnT.Parsers.Xml.Parsers.Query
{
    public class XmlQueryParser<T> where T : class, IQueryRequestProvider
    {
        private readonly XmlSerializer _querySerializer;

        public XmlQueryParser()
        {
            _querySerializer = new XmlSerializer(typeof(T));
        }

        public virtual async Task<IQueryRequest> Read(Stream input, CancellationToken cancellationToken)
        {
            var query = _querySerializer.Deserialize(input) as T;

            return await Task.FromResult(query.GetEpcisRequest());
        }
    }

    public interface IQueryRequestProvider
    {
        IQueryRequest GetEpcisRequest();
    }
}
