﻿using FasTnT.Host.Infrastructure.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FasTnT.Host.Controllers.v1_2
{
    [Formatter(Format.Soap)]
    [ApiController, Route("v1_2/Query.svc")]
    public class EpcisSoapQueryController : EpcisQueryController
    {
        public EpcisSoapQueryController(IMediator dispatcher) : base(dispatcher)
        {
        }
    }
}
