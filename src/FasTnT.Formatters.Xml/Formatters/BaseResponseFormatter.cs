using FasTnT.Commands.Responses;
using FasTnT.Domain.Commands;
using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Formatters
{
    public abstract class BaseResponseFormatter<TResponse> : IResponseFormatter, IResponseVisitor
        where TResponse : class
    {
        public static XmlSerializer _serializer = new XmlSerializer(typeof(TResponse));
        internal TResponse FormattedResponse { get; set; }

        public Task FormatAsync(IEpcisResponse epcisResponse, Stream body, CancellationToken cancellationToken)
        {
            return Task.Run(() =>
            {
                epcisResponse.Accept(this);

                if (FormattedResponse == default)
                {
                    throw new NotImplementedException($"Cannot serialize response of type {epcisResponse.GetType().Name}");
                }
                else
                {
                    var writer = XmlWriter.Create(body, new XmlWriterSettings { NamespaceHandling = NamespaceHandling.OmitDuplicates });

                    _serializer.Serialize(writer, FormattedResponse, XmlEpcisNamespaces.Namespaces);
                }
            }, cancellationToken);
        }

        public abstract void Visit(ExceptionResponse response);
        public abstract void Visit(GetQueryNamesResponse response);
        public abstract void Visit(GetStandardVersionResponse response);
        public abstract void Visit(GetSubscriptionIdsResponse response);
        public abstract void Visit(GetVendorVersionResponse response);
        public abstract void Visit(PollResponse response);
        public abstract void Visit(EmptyResponse response);
    }
}
