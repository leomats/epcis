using MediatR;
using FasTnT.Domain.Queries;
using Microsoft.Extensions.DependencyInjection;
using System;
using FasTnT.Domain.Commands;
using System.Linq;

namespace FasTnT.Domain
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddEpcisDomain(this IServiceCollection services)
        {
            services.AddMediatR(Constants.Assembly);

            services.AddScoped<RequestContext>();
            services.AddScoped<IEpcisQuery, SimpleEventQuery>();
            services.AddScoped<IEpcisQuery, SimpleMasterdataQuery>();

            services.AddScoped<Func<string, ICommandFormatter>>(svc => format =>
            {
                var formatters = svc.GetServices<ICommandFormatter>();

                return formatters.FirstOrDefault(x => x.CanHandle(format));
            });

            return services;
        }
    }
}
