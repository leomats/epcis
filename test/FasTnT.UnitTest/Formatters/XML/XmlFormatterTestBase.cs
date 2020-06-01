using FasTnT.Commands.Responses;
using FasTnT.Parsers.Xml;
using FasTnT.UnitTest;
using System.IO;
using System.Threading.Tasks;

namespace FasTnT.IntegrationTests.Formatters.XML
{
    public abstract class XmlFormatterTestBase : TestBase
    {
        //public XmlCommandFormatter Formatter { get; set; }
        public IEpcisResponse Response { get; set; }
        public string Formatted { get; set; }

        public override void Given()
        {
            //Formatter = new XmlCommandFormatter();
        }

        public override void When()
        {
            using(var stream = new MemoryStream())
            {
                // TODO: Task.WaitAll(Formatter.WriteResponse(Response, stream, default));
                stream.Seek(0, SeekOrigin.Begin);

                using (var reader = new StreamReader(stream))
                {
                    Formatted = reader.ReadToEnd();
                }
            }
        }
    }
}
