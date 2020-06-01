using FasTnT.Commands.Responses;
using FasTnT.Domain.Commands;
using FasTnT.Parsers.Xml;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FasTnT.Subscriptions
{
    public class SubscriptionResultSender
    {
        private readonly Func<string, ICommandFormatter> _formatterFactory;

        public SubscriptionResultSender(Func<string, ICommandFormatter> formatterFactory)
        {
            _formatterFactory = formatterFactory;
        }

        public async Task SendAsync(string destination, IEpcisResponse epcisResponse, string format, CancellationToken cancellationToken)
        {
            var formatter = _formatterFactory(format);
            var request = WebRequest.CreateHttp(destination);
            request.Method = "POST";
            request.ContentType = formatter.ContentType;
            TrySetBasicAuthorization(request);

            using (var stream = await request.GetRequestStreamAsync())
            {
                await formatter.WriteResponse(epcisResponse, stream, cancellationToken);
            }

            using (var response = await request.GetResponseAsync() as HttpWebResponse)
            using (var responseMessage = new HttpResponseMessage(response.StatusCode))
            {
                if (!responseMessage.IsSuccessStatusCode)
                {
                    throw new Exception($"Response does not indicate success status code: {response.StatusCode} ({response.StatusDescription})");
                }
            }
        }

        private void TrySetBasicAuthorization(HttpWebRequest request)
        {
            if (!string.IsNullOrEmpty(request.RequestUri.UserInfo))
            {
                var token = Convert.ToBase64String(Encoding.UTF8.GetBytes(WebUtility.UrlDecode(request.RequestUri.UserInfo)));
                request.Headers.Add("Authorization", $"Basic {token}");
            }
        }
    }
}
