using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Queries
{
    [XmlType("GetQueryNames", Namespace = "urn:epcglobal:epcis-query:xsd:1")]
    public class GetQueryNames : EpcisXmlQuery
    {
    }
}
