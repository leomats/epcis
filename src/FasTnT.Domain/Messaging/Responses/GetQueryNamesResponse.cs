﻿using FasTnT.Domain.Commands;

namespace FasTnT.Commands.Responses
{
    public class GetQueryNamesResponse : IEpcisResponse
    {
        public string[] QueryNames { get; set; }

        public void Accept(IResponseVisitor responseFormatter)
        {
            responseFormatter.Visit(this);
        }
    }
}
