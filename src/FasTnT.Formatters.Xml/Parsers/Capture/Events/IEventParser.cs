using System.Xml.Linq;
using FasTnT.Model.Events;

namespace FasTnT.Parsers.Xml.Capture
{
    public interface IEventParser
    {
        bool CanParse(XName name);
        EpcisEvent Parse(XElement element);
    }
}
