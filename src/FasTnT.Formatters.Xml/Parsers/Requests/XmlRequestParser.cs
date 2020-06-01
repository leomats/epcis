using FasTnT.Domain.Commands;
using FasTnT.Formatters.Xml.Model.Events;
using System.IO;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Parsers.Requests
{
    public class XmlRequestParser<T> where T : class, ICaptureRequestProvider
    {
        private static readonly XmlSerializer _captureSerializer = new XmlSerializer(typeof(T));

        public Task<ICaptureRequest> ReadRequest(Stream input)
        {
            var request = _captureSerializer.Deserialize(input) as T;

            return Task.FromResult(request.GetEpcisCaptureRequest());
        }
    }
}
