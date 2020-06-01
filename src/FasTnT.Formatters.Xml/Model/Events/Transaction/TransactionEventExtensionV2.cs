using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events.Transaction
{
    public class TransactionEventExtensionV2
    {
        [XmlAnyElement]
        public XmlElement[] CustomFields { get; set; }
    }
}
