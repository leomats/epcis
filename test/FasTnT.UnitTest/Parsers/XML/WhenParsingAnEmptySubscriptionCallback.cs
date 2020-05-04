using FasTnT.Commands.Requests;
using FasTnT.Model.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Diagnostics;

namespace FasTnT.UnitTest.Parsers.XML
{
    [TestClass]
    public class WhenParsingAnEmptySubscriptionCallback : XmlRequestParserTestBase
    {
        public override void Given()
        {
            SetRequest("<?xml version=\"1.0\" encoding=\"utf-8\"?><epcisq:EPCISQueryDocument xmlns:epcisq=\"urn:epcglobal:epcis-query:xsd:1\" creationDate=\"2019-01-26T20:10:01.8111457Z\" schemaVersion=\"1\"><EPCISBody><epcisq:QueryResults><queryName>SimpleEventQuery</queryName><subscriptionID>TestSubscriptionID</subscriptionID><resultsBody><EventList /></resultsBody></epcisq:QueryResults></EPCISBody></epcisq:EPCISQueryDocument>");
        }

        [TestMethod]
        public void ItShouldReturnARequest()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.IsNotNull(captureRequest);
        }

        [TestMethod]
        public void TheRequestShouldNotContainEvents()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(0, captureRequest.Request.EventList.Count);
        }

        [TestMethod]
        public void TheRequestShouldNotContainOneMasterdata()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(0, captureRequest.Request.MasterdataList.Count);
        }

        [TestMethod]
        public void TheRequestShouldContainSubscriptionInformation()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.IsNotNull(captureRequest.Request.SubscriptionCallback);
        }

        [TestMethod]
        public void TheRequestShouldContainTheCorrectSubscriptionId()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual("TestSubscriptionID", captureRequest.Request.SubscriptionCallback.SubscriptionId);
        }

        [TestMethod]
        public void TheRequestShouldContainTheCallbackTypeSuccess()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(QueryCallbackType.Success, captureRequest.Request.SubscriptionCallback.CallbackType);
        }

        [TestMethod]
        public void TheRequestShouldNotHaveAReason()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(default, captureRequest.Request.SubscriptionCallback.Reason);
        }
    }
}
