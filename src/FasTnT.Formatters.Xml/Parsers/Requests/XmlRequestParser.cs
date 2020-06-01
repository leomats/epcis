using FasTnT.Domain.Commands;
using FasTnT.Formatters.Xml.Model.Events;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Parsers.Requests
{
    public class XmlRequestParser
    {
        private static readonly XmlSerializer _captureSerializer = new XmlSerializer(typeof(XmlEpcisRequest));

        public Task<ICaptureRequest> ReadRequest(Stream input)
        {
            var request = _captureSerializer.Deserialize(input) as XmlEpcisRequest;

            return Task.FromResult(request.GetEpcisCaptureRequest());
        }
    }
}
