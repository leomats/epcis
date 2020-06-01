using FasTnT.Model.Events;
using System;
using System.Xml;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events
{
    public abstract class BaseEpcisEvent
    {
        [XmlElement(ElementName = "eventTime", IsNullable = false)]
        public DateTime EventDate { get; set; }
        [XmlElement(ElementName = "captureTime")]
        public DateTime? RecordTime { get; set; }
        [XmlElement(ElementName = "eventTimeZoneOffset", IsNullable = false)]
        public string EventTimeZoneOffset { get; set; }
        [XmlElement(ElementName = "baseExtension")]
        public BaseEpcisEventExtensionV1 BaseExtension { get; set; }

        public virtual EpcisEvent GetEpcisEvent()
        {
            var epcisEvent = new EpcisEvent
            {
                EventTime = EventDate,
                EventTimeZoneOffset = new TimeZoneOffset { Representation = EventTimeZoneOffset },
            };

            return epcisEvent;
        }
    }
}
