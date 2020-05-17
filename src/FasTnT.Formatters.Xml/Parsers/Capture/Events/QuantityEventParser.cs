using FasTnT.Model.Enums;
using FasTnT.Formatters.Xml.Parsers.Capture.Parsers;

namespace FasTnT.Parsers.Xml.Capture
{
    public class QuantityEventParser : BaseEventParser, IRootEventParser
    {
        public QuantityEventParser(IRootEventElementParser[] parsers)
            : base(parsers, EventType.Quantity)
        {
        }
    }
}
