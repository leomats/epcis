using System.Collections.Generic;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Queries.Outbound
{

    public class GetQueryNamesResult : EpcisXmlResult
    {
        [XmlElement(ElementName = "string")]
        public List<string> QueryNames { get; set; }
    }
}
