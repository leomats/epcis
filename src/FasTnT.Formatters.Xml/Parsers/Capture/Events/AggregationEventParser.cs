using FasTnT.Model.Enums;
using FasTnT.Formatters.Xml.Parsers.Capture.Parsers;

namespace FasTnT.Parsers.Xml.Capture
{
    public class AggregationEventParser : BaseEventParser, IRootEventParser
    {
        public AggregationEventParser(IRootEventElementParser[] parsers)
            : base(parsers, EventType.Aggregation)
        {
        }
    }
}
