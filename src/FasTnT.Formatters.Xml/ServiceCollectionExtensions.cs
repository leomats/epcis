using FasTnT.Domain.Commands;
using FasTnT.Formatters.Xml.Model.Events;
using FasTnT.Formatters.Xml.Model.Queries;
using FasTnT.Parsers.Xml;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace FasTnT.Formatters.Xml
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddXmlFormatters(this IServiceCollection services)
        {
            services.AddSingleton<Func<string, ICommandFormatter>>((format) =>
            {
                switch (format)
                {
                    case "soap":
                        return new XmlCommandFormatter<XmlEpcisRequest, SoapQueryDocument>();
                    case "xml":
                        return new XmlCommandFormatter<XmlEpcisRequest, XmlQueryDocument>();
                    default:
                        throw new NotImplementedException($"Unknown format: {format}");
                }
            });

            return services;
        }
    }
}
