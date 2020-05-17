using FasTnT.Parsers.Xml.Capture;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Parsers.Capture.Parsers
{
    public interface IRootEventElementParser : IEventElementParser
    {
    }

    public interface IEventElementParser
    {
        bool CanParse(XName name);
        void Parse(XElement element, IEventBuilder builder);
    }
}
