using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events
{
    public class ErrorDeclaration
    {
        public DateTime DeclarationTime { get; set; }
        public string Reason { get; set; }
        public List<string> CorrectiveEventIds { get; set; }
        [XmlAnyElement]
        public XmlElement[] CustomFields { get; set; }
    }
}
