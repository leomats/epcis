using FasTnT.Domain.Commands;
using FasTnT.Formatters.Xml.Formatters;
using FasTnT.Parsers.Xml;
using Microsoft.Extensions.DependencyInjection;

namespace FasTnT.Formatters.Xml
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddXmlFormatters(this IServiceCollection services)
        {
            services.AddSingleton<ICommandFormatter>(new CommandFormatter("xml", "application/xml", new XmlCaptureReader(), new XmlQueryReader(), new XmlResponseFormatter()));
            services.AddSingleton<ICommandFormatter>(new CommandFormatter("soap", "application/xml", null, new SoapQueryReader(), new SoapResponseFormatter()));

            return services;
        }
    }
}
