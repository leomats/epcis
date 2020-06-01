using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Formatters
{
    public static class XmlEpcisNamespaces
    {
        public static XmlSerializerNamespaces Namespaces = new XmlSerializerNamespaces(new[]
        {
            new XmlQualifiedName("epcisq", "urn:epcglobal:epcis-query:xsd:1"),
            new XmlQualifiedName("sbdh", "http://www.unece.org/cefact/namespaces/StandardBusinessDocumentHeader"),
            new XmlQualifiedName("epcis", "urn:epcglobal:epcis:xsd:1")
        });
    }
}
