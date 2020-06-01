using FasTnT.Commands.Responses;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FasTnT.Domain.Commands
{
    public class CommandFormatter : ICommandFormatter
    {
        private readonly ICaptureReader _captureReader;
        private readonly IQueryReader _queryReader;
        private readonly IResponseFormatter _responseFormatter;

        public string ContentType { get; private set; }
        public string Format { get; private set; }

        public bool CanHandle(string format) => format == Format;

        public CommandFormatter(string format, string contentType, ICaptureReader captureReader = default, IQueryReader queryReader = default, IResponseFormatter responseFormatter = default)
        {
            Format = format;
            ContentType = contentType;

            _captureReader = captureReader;
            _queryReader = queryReader;
            _responseFormatter = responseFormatter;
        }

        public async Task<ICaptureRequest> ParseCapture(Stream input, CancellationToken cancellationToken)
        {
            return await _captureReader.ReadAsync(input, cancellationToken);
        }

        public async Task<IQueryRequest> ParseQuery(Stream input, CancellationToken cancellationToken)
        {
            return await _queryReader.ReadAsync(input, cancellationToken);
        }

        public async Task WriteResponse(IEpcisResponse epcisResponse, Stream body, CancellationToken cancellationToken)
        {
            await _responseFormatter.FormatAsync(epcisResponse, body, cancellationToken);
        }
    }
}
