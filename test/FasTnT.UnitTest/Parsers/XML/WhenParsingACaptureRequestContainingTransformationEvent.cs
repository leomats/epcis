using FasTnT.Commands.Requests;
using FasTnT.Model.Enums;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Linq;

namespace FasTnT.UnitTest.Parsers.XML
{
    [TestClass]
    public class WhenParsingACaptureRequestContainingTransformationEvent : XmlRequestParserTestBase
    {
        public override void Given()
        {
            SetRequest(File.ReadAllText("Files/XML/Capture_Transformation.xml"));
        }

        public void ItShouldReturnARequest()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.IsNotNull(captureRequest);
        }

        [TestMethod]
        public void TheRequestShouldContainOneEvent()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(1, captureRequest.Request.EventList.Count);
        }

        [TestMethod]
        public void TheEventShouldBeOfTypeTransformation()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(EventType.Transformation, captureRequest.Request.EventList[0].Type);
        }

        [TestMethod]
        public void TheEventShouldHaveACustomField()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(1, captureRequest.Request.EventList[0].CustomFields.Count);
        }

        [TestMethod]
        public void TheEventCustomFieldShouldBeACustomField()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(FieldType.CustomField, captureRequest.Request.EventList[0].CustomFields[0].Type);
        }

        [TestMethod]
        public void TheEventShouldHave2Epcs()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(2, captureRequest.Request.EventList[0].Epcs.Count);
        }

        [TestMethod]
        public void TheEventShouldHaveTheCorrectEpcTypes()
        {
            var captureRequest = Result as CaptureEpcisDocumentRequest;
            Assert.AreEqual(1, captureRequest.Request.EventList[0].Epcs.Count(e => e.Type == EpcType.OutputQuantity));
            Assert.AreEqual(1, captureRequest.Request.EventList[0].Epcs.Count(e => e.Type == EpcType.InputEpc));
        }
    }
}
