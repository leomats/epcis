﻿using FasTnT.Host.Infrastructure.Attributes;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FasTnT.Host.Controllers.v1_2
{
    [Formatter(Format.Xml)]
    [ApiController, Route("v1_2/Query")]
    public class EpcisXmlQueryController : EpcisQueryController
    {
        public EpcisXmlQueryController(IMediator dispatcher) : base(dispatcher)
        {
        }
    }
}
