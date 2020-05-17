using FasTnT.Model.Enums;
using FasTnT.Formatters.Xml.Parsers.Capture.Parsers;

namespace FasTnT.Parsers.Xml.Capture
{
    public class TransactionEventParser : BaseEventParser, IRootEventParser
    {
        public TransactionEventParser(IRootEventElementParser[] parsers)
            : base(parsers, EventType.Transaction)
        {
        }
    }
}
