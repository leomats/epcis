using FasTnT.Domain.Commands;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Microsoft.Extensions.DependencyInjection;
using FasTnT.Domain;

namespace FasTnT.Host.Infrastructure.Attributes
{
    public class FormatterAttribute : Attribute, IFilterFactory
    {
        private readonly string _format;

        public FormatterAttribute(string format) => _format = format;

        public bool IsReusable => false;
        public IFilterMetadata CreateInstance(IServiceProvider serviceProvider) => new FormatterResourceFilter(_format);

        private class FormatterResourceFilter : IResourceFilter
        {
            private readonly string _format;

            public FormatterResourceFilter(string format) => _format = format;

            public void OnResourceExecuted(ResourceExecutedContext context) { }
            public void OnResourceExecuting(ResourceExecutingContext context)
            {
                var formatterProvider = context.HttpContext.RequestServices.GetService<Func<string, ICommandFormatter>>();
                var formatter = formatterProvider(_format);

                context.HttpContext.RequestServices.GetService<RequestContext>().Formatter = formatter;
            }
        }
    }
}
