﻿using FasTnT.Commands.Responses;
using FasTnT.Domain.Commands;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace FasTnT.Host.Controllers.v1_2
{
    [Authorize]
    public abstract class EpcisQueryController : ControllerBase
    {
        private readonly IMediator _dispatcher;

        public EpcisQueryController(IMediator dispatcher) => _dispatcher = dispatcher;

        [HttpPost]
        public async Task<IEpcisResponse> Query(IQueryRequest query, CancellationToken cancellationToken) => await _dispatcher.Send(query, cancellationToken);
    }
}
