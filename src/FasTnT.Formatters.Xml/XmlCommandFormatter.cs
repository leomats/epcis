using FasTnT.Commands.Responses;
using FasTnT.Domain.Commands;
using FasTnT.Formatters.Xml.Model.Queries;
using FasTnT.Formatters.Xml.Parsers.Requests;
using FasTnT.Parsers.Xml.Parsers.Query;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace FasTnT.Parsers.Xml
{
    public class XmlCommandFormatter : ICommandFormatter
    {
        public string ContentType => "application/xml";

        public async Task<ICaptureRequest> ParseCapture(Stream input, CancellationToken cancellationToken)
        {
            var requestParser = new XmlRequestParser();

            return await requestParser.ReadRequest(input);
        }

        public async Task<IQueryRequest> ParseQuery(Stream input, CancellationToken cancellationToken)
        {
            var queryParser = new XmlQueryParser<EpcisQueryDocument>();

            return await queryParser.Read(input, cancellationToken);
        }

        public async Task WriteResponse(IEpcisResponse epcisResponse, Stream body, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
            //var formatter = new XmlResponseFormatter();

            //await formatter.Write(epcisResponse, body, cancellationToken);
        }
    }
}
