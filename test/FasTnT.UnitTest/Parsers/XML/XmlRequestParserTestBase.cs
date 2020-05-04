using FasTnT.Domain.Commands;
using FasTnT.Parsers.Xml.Capture;
using System.IO;

namespace FasTnT.UnitTest.Parsers.XML
{
    public abstract class XmlRequestParserTestBase : TestBase
    {
        public MemoryStream CaptureStream { get; set; }
        public ICaptureRequest Result { get; set; }

        public override void When()
        {
            Result = new XmlRequestParser().Read(CaptureStream, default).Result;
        }

        public void SetRequest(string request)
        {
            CaptureStream = new MemoryStream();
            var sw = new StreamWriter(CaptureStream);
            sw.WriteLine(request);
            sw.Flush();
            CaptureStream.Seek(0, SeekOrigin.Begin);
        }
    }
}
