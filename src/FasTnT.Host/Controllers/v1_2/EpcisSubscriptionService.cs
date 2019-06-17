﻿using FasTnT.Domain.Services;
using FasTnT.Host.Infrastructure.Attributes;
using FasTnT.Model.Subscriptions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace FasTnT.Host.Controllers.v1_2
{
    [Authorize]
    [Formatter(Format.Xml)]
    [Route("v1_2/Subscription")]
    public class EpcisSubscriptionService : Controller
    {
        private readonly SubscriptionService _service;

        public EpcisSubscriptionService(SubscriptionService service) => _service = service;

        [HttpGet("trigger/{triggerName}")]
        public async Task TriggerSubscription(string triggerName, CancellationToken cancellationToken)
        {
            await _service.Process(new TriggerSubscriptionRequest { Trigger = triggerName }, cancellationToken);   
        }
    }
}
