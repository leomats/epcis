using FasTnT.Model.Events;
using FasTnT.Parsers.Xml.Capture;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Parsers.Capture.Parsers
{
    public class BusinessTransactionListElementParser : IRootEventElementParser
    {
        public bool CanParse(XName name) => name.LocalName == "bizTransactionList" && string.IsNullOrEmpty(name.NamespaceName);

        public void Parse(XElement element, IEventBuilder builder)
        {
            var businessTransactions = ParseTransactions(element);

            builder.AddBusinessTransactions(businessTransactions);
        }

        private static BusinessTransaction[] ParseTransactions(XElement element)
        {
            var businessTransactions = new List<BusinessTransaction>(element.Elements().Count());

            foreach (var businessTransaction in element.Elements())
            {
                businessTransactions.Add(new BusinessTransaction
                {
                    Type = businessTransaction.Attribute("type").Value,
                    Id = businessTransaction.Value
                });
            }

            return businessTransactions.ToArray();
        }
    }
}
