﻿using FasTnT.Commands.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FasTnT.UnitTest.Parsers.XML
{
    [TestClass]
    public class WhenParsingXmlGetSubscriptionIDsRequest : XmlQueryParserTestBase
    {
        public override void Given()
        {
            SetRequest("<?xml version=\"1.0\" encoding=\"utf-8\"?><epcisq:EPCISQueryDocument xmlns:epcisq=\"urn:epcglobal:epcis-query:xsd:1\" creationDate=\"2019-01-26T20:10:01.8111457Z\" schemaVersion=\"1\"><EPCISBody><epcisq:GetSubscriptionIDs><queryName>SimpleEventQuery</queryName></epcisq:GetSubscriptionIDs></EPCISBody></epcisq:EPCISQueryDocument>");
        }

        [TestMethod]
        public void ItShouldReturnAGetSubscriptionIDsRequest()
        {
            Assert.IsInstanceOfType(Result, typeof(GetSubscriptionIdsRequest));
        }

        [TestMethod]
        public void ItShouldContainTheExpectedQueryName()
        {
            var getSubscriptionIdsRequest = (GetSubscriptionIdsRequest) Result;

            Assert.AreEqual("SimpleEventQuery", getSubscriptionIdsRequest.QueryName);
        }
    }
}
