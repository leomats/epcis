using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events.Transaction
{
    public class TransactionEventExtensionV1
    {
        [XmlElement(ElementName = "quantityList", IsNullable = true)]
        public List<string> QuantityList { get; set; }
        [XmlArray(ElementName = "sourceList"), XmlArrayItem(ElementName = "source")]
        public List<SourceDestination> Sources { get; set; }
        [XmlArray(ElementName = "destinationList"), XmlArrayItem(ElementName = "destination")]
        public List<SourceDestination> Destinations { get; set; }
        [XmlElement(ElementName = "extension", IsNullable = true)]
        public TransactionEventExtensionV2 Extension { get; set; }
        [XmlAnyElement]
        public XmlElement[] CustomFields { get; set; }
    }
}
