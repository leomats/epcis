using FasTnT.Domain.Commands;
using FasTnT.Parsers.Xml.Parsers.Query;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FasTnT.Parsers.Xml
{
    public class BaseQueryReader<T> : IQueryReader where T : class, IQueryRequestProvider
    {
        private static XmlSerializer _serializer = new XmlSerializer(typeof(T));
        public Task<IQueryRequest> ReadAsync(Stream input, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var query = _serializer.Deserialize(input) as T;

                return query.GetEpcisRequest();
            }, cancellationToken);
        }
    }
}