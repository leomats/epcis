using FasTnT.Model.Enums;
using FasTnT.Formatters.Xml.Parsers.Capture.Parsers;

namespace FasTnT.Parsers.Xml.Capture
{
    public class TransformationEventParser : BaseEventParser, IExtensionEventParser
    {
        public TransformationEventParser(IRootEventElementParser[] parsers)
            : base(parsers, EventType.Transformation)
        {
        }
    }
}
