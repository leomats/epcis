using FasTnT.Commands.Responses;
using FasTnT.Domain.Commands;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Formatters
{
    public abstract class BaseResponseFormatter<TResponse> : IResponseFormatter
    {
        public static XmlSerializer _serializer = new XmlSerializer(typeof(TResponse));

        public Task FormatAsync(IEpcisResponse epcisResponse, Stream body, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var writer = XmlWriter.Create(body, new XmlWriterSettings { NamespaceHandling = NamespaceHandling.OmitDuplicates });
                
                _serializer.Serialize(writer, FormatResponse(epcisResponse), XmlEpcisNamespaces.Namespaces);
            }, cancellationToken);
        }

        public abstract TResponse FormatResponse(IEpcisResponse response);
    }
}
