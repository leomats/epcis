using FasTnT.Domain.Commands;
using System;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Queries
{
    public abstract class EpcisXmlQuery
    {
        internal virtual IQueryRequest GetEpcisRequest()
        {
            throw new NotImplementedException($"Cannot get EPCIS request from Element {GetType().Name}");
        }
    }
}
