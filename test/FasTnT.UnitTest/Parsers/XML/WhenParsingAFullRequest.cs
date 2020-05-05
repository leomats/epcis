using FasTnT.Commands.Requests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;

namespace FasTnT.UnitTest.Parsers.XML
{
    [TestClass]
    public class WhenParsingAFullRequest : XmlRequestParserTestBase
    {
        public override void Given()
        {
             SetRequest(File.ReadAllText("Files/XML/FullCapture.xml"));
        }

        public void ItShouldReturnARequest()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.IsNotNull(captureRequest);
        }

        [TestMethod]
        public void TheRequestShouldContainOneMasterdata()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(1, captureRequest.Request.MasterdataList.Count);
        }

        [TestMethod]
        public void TheRequestShouldContainOneEvent()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(1, captureRequest.Request.EventList.Count);
        }

        [TestMethod]
        public void TheRequestShouldContainAStandardBusinessHeader()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.IsNotNull(captureRequest.Request.StandardBusinessHeader);
        }
    }
}
