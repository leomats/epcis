using FasTnT.Commands.Responses;
using FasTnT.Domain.Data;
using FasTnT.Domain.Model.Subscriptions;
using FasTnT.Domain.Queries;
using FasTnT.Model.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;

namespace FasTnT.Subscriptions
{
    public class SubscriptionRunner
    {
        public static Assembly Assembly = typeof(SubscriptionRunner).Assembly;

        private readonly IEnumerable<IEpcisQuery> _epcisQueries;
        private readonly ISubscriptionManager _subscriptionManager;
        private readonly SubscriptionResultSender _resultSender;

        public SubscriptionRunner(IEnumerable<IEpcisQuery> epcisQueries, ISubscriptionManager subscriptionManager, SubscriptionResultSender resultSender)
        {
            _epcisQueries = epcisQueries;
            _subscriptionManager = subscriptionManager;
            _resultSender = resultSender;
        }

        public async Task Run(Subscription subscription, CancellationToken cancellationToken)
        {
            var query = _epcisQueries.Single(x => x.Name == subscription.QueryName);
            var response = new PollResponse();

            try
            {
                var pendingRequests = await _subscriptionManager.GetPendingRequestIds(subscription.Id.Value, cancellationToken);

                if (pendingRequests.Any())
                {
                    var parameters = subscription.Parameters.Append(BuildRequestIdsParameter(pendingRequests));
                    response = await query.HandleAsync(parameters.ToArray(), cancellationToken);
                }

                response.QueryName = query.Name;
                response.SubscriptionId = subscription.SubscriptionId;

                await SendSubscriptionResultsAsync(subscription, response, cancellationToken);
                await _subscriptionManager.AcknowledgePendingRequestsAsync(subscription.Id.Value, pendingRequests, cancellationToken);
                await _subscriptionManager.RegisterSubscriptionTriggerAsync(subscription.Id.Value, SubscriptionResult.Success, default, cancellationToken);
            }
            catch (Exception ex)
            {
                await _subscriptionManager.RegisterSubscriptionTriggerAsync(subscription.Id.Value, SubscriptionResult.Failed, ex.Message, cancellationToken);
            }
        }

        private static QueryParameter BuildRequestIdsParameter(int[] pendingRequests)
        {
            return new QueryParameter
            {
                Name = "EQ_requestId",
                Values = pendingRequests.Select(x => x.ToString()).ToArray()
            };
        }

        private async Task SendSubscriptionResultsAsync(Subscription subscription, PollResponse response, CancellationToken cancellationToken)
        {
            if (response.EventList.Count() > 0 || subscription.ReportIfEmpty)
            {
                await _resultSender.SendAsync(subscription.Destination, response, subscription.Format, cancellationToken);
            }
        }
    }
}
