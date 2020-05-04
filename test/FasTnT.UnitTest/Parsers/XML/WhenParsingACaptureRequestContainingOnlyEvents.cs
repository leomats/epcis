using FasTnT.Commands.Requests;
using FasTnT.Model.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FasTnT.UnitTest.Parsers.XML
{
    [TestClass]
    public class WhenParsingARequestContainingOnlyEvents : XmlRequestParserTestBase
    {
        public override void Given()
        {
            SetRequest("<?xml version=\"1.0\" encoding=\"UTF-8\"?><epcis:EPCISDocument xmlns:epcis=\"urn:epcglobal:epcis:xsd:1\" xmlns:tl=\"http://epcis.tracelink.com/ns\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" schemaVersion=\"1.2\" creationDate=\"2018-06-12T06:31:32Z\"><EPCISBody><EventList><AggregationEvent><eventTime>2018-06-12T06:31:32Z</eventTime><eventTimeZoneOffset>-04:00</eventTimeZoneOffset><parentID>urn:epc:id:sscc:005434.40000000019</parentID><childEPCs><epc>urn:epc:id:sgtin:068202.0401034.11220207026272</epc></childEPCs><action>ADD</action><bizStep>urn:epcglobal:cbv:bizstep:packing</bizStep><disposition>urn:epcglobal:cbv:disp:in_progress</disposition><bizLocation><id>urn:epc:id:sgln:9297187.01994.0</id></bizLocation><tl:aggregationEventExtensions><tl:epcOrderItemDetails><tl:epcOrderItemList orderItemNumber=\"910\"><tl:epcOrderItem>urn:epc:id:sscc:005434.40000000019</tl:epcOrderItem></tl:epcOrderItemList></tl:epcOrderItemDetails></tl:aggregationEventExtensions></AggregationEvent></EventList></EPCISBody></epcis:EPCISDocument>");
        }

        [TestMethod]
        public void ItShouldReturnARequest()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.IsNotNull(captureRequest);
        }

        [TestMethod]
        public void TheRequestShouldNotContainMasterdata()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(0, captureRequest.Request.MasterdataList.Count);
        }

        [TestMethod]
        public void TheRequestShouldNotContainSubscriptionInformation()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.IsNull(captureRequest.Request.SubscriptionCallback);
        }

        [TestMethod]
        public void TheRequestShouldContainOneEvent()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(1, captureRequest.Request.EventList.Count);
        }

        [TestMethod]
        public void TheEventShouldBeOfTypeAggregation()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(EventType.Aggregation, captureRequest.Request.EventList[0].Type);
        }

        [TestMethod]
        public void TheEventShouldHaveOneCustomField()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(1, captureRequest.Request.EventList[0].CustomFields.Count);
        }

        [TestMethod]
        public void TheEventShouldHave2Epcs()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(2, captureRequest.Request.EventList[0].Epcs.Count);
        }

        [TestMethod]
        public void TheEventShouldHaveTheCorrectTimezoneOffset()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(-240, captureRequest.Request.EventList[0].EventTimeZoneOffset.Value);
        }
    }
}
