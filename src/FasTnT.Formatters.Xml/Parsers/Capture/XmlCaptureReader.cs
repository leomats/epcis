using FasTnT.Domain.Commands;
using FasTnT.Formatters.Xml.Model.Events;
using FasTnT.Parsers.Xml.Parsers.Query;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FasTnT.Parsers.Xml
{
    public class XmlCaptureReader : ICaptureReader
    {
        private static readonly XmlSerializer _serializer = new XmlSerializer(typeof(XmlEpcisRequest));

        public Task<ICaptureRequest> ReadAsync(Stream input, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                var xmlRequest = _serializer.Deserialize(input) as XmlEpcisRequest;

                return xmlRequest.GetEpcisCaptureRequest();
            }, cancellationToken);
        }
    }
}
