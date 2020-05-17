using FasTnT.Model.Enums;
using FasTnT.Formatters.Xml.Parsers.Capture.Parsers;

namespace FasTnT.Parsers.Xml.Capture
{
    public class ObjectEventParser : BaseEventParser, IRootEventParser
    {
        public ObjectEventParser(IRootEventElementParser[] parsers)
            : base(parsers, EventType.Object)
        {
        }
    }

    public interface IRootEventParser : IEventParser
    {
    }

    public interface IExtensionEventParser : IEventParser
    {
    }
}
