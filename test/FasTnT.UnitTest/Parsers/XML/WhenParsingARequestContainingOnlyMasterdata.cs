using FasTnT.Commands.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FasTnT.UnitTest.Parsers.XML
{
    [TestClass]
    public class WhenParsingARequestContainingOnlyMasterdata : XmlRequestParserTestBase
    {
        public override void Given()
        {
            SetRequest("<epcismd:EPCISMasterDataDocument xmlns:epcismd=\"urn:epcglobal:epcis-masterdata:xsd:1\" xmlns:xsi=\"http://www.w3.org/2001/XMLSchema-instance\" schemaVersion=\"1.0\" creationDate=\"2005-07-11T11:30:47.0Z\"><EPCISBody><VocabularyList><Vocabulary type=\"urn:epcglobal:epcis:vtype:BusinessLocation\"><VocabularyElementList><VocabularyElement id=\"urn:epc:id:sgln:0037000.00729.8203\"><attribute id=\"urn:epcglobal:cbv:mda:sst\">202</attribute><attribute id=\"urn:epcglobal:cbv:mda:ssa\">402</attribute></VocabularyElement></VocabularyElementList></Vocabulary></VocabularyList></EPCISBody></epcismd:EPCISMasterDataDocument>");
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
        public void TheRequestShouldNotContainSubscriptionInformation()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.IsNull(captureRequest.Request.SubscriptionCallback);
        }

        [TestMethod]
        public void TheRequestShouldContainOneMasterdata()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(1, captureRequest.Request.MasterdataList.Count);
        }

        [TestMethod]
        public void TheMasterdataShouldHaveTheCorrectType()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual("urn:epcglobal:epcis:vtype:BusinessLocation", captureRequest.Request.MasterdataList[0].Type);
        }

        [TestMethod]
        public void TheMasterdataShouldHaveTheCorrectId()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual("urn:epc:id:sgln:0037000.00729.8203", captureRequest.Request.MasterdataList[0].Id);
        }

        [TestMethod]
        public void TheMasterdataShouldHave2Attributes()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(2, captureRequest.Request.MasterdataList[0].Attributes.Count);
        }
    }
}
