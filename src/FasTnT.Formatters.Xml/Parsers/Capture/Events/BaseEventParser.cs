using FasTnT.Model.Enums;
using System.Xml.Linq;
using FasTnT.Model.Events;
using FasTnT.Formatters.Xml.Parsers.Capture.Parsers;
using System.Linq;
using System;

namespace FasTnT.Parsers.Xml.Capture
{
    public abstract class BaseEventParser : IEventBuilder
    {
        private readonly IRootEventElementParser[] _parsers;
        private readonly EventType _eventType;
        private readonly EpcisEvent _epcisEvent;

        public BaseEventParser(IRootEventElementParser[] parsers, EventType eventType)
        {
            _parsers = parsers;
            _eventType = eventType;
            _epcisEvent = new EpcisEvent();
        }

        public bool CanParse(XName name)
        {
            return name.LocalName == _eventType.DisplayName && string.IsNullOrEmpty(name.NamespaceName);
        }

        public EpcisEvent Parse(XElement element)
        {
            _epcisEvent.Type = _eventType;

            foreach(var objectElement in element.Elements())
            {
                var parser = _parsers.FirstOrDefault(x => x.CanParse(objectElement.Name));

                if(parser != null)
                {
                    parser.Parse(objectElement, this);
                }
            }

            return _epcisEvent;
        }

        public void SetEventTime(DateTime eventTime)
        {
            _epcisEvent.EventTime = eventTime;
        }

        public void SetAction(EventAction action)
        {
            _epcisEvent.Action = action;
        }

        public void SetEventTimeZoneOffset(TimeZoneOffset timeZoneOffset)
        {
            _epcisEvent.EventTimeZoneOffset = timeZoneOffset;
        }

        public void AddBusinessTransactions(params BusinessTransaction[] businessTransactions)
        {
            _epcisEvent.BusinessTransactions.AddRange(businessTransactions);
        }

        public void AddEpcs(params Epc[] epcs)
        {
            _epcisEvent.Epcs.AddRange(epcs);
        }

        public void SetBusinessStep(string businessStep)
        {
            _epcisEvent.BusinessStep = businessStep;
        }

        public void SetDisposition(string disposition)
        {
            _epcisEvent.Disposition = disposition;
        }

        public void SetReadPoint(string readPoint)
        {
            _epcisEvent.ReadPoint = readPoint;
        }

        public void AddCustomFields(params CustomField[] customFields)
        {
            _epcisEvent.CustomFields.AddRange(customFields);
        }

        public void SetEventId(string eventId)
        {
            _epcisEvent.EventId = eventId;
        }

        public void SetTransformationId(string transformationId)
        {
            _epcisEvent.TransformationId = transformationId;
        }

        public void SetBusinessLocation(string businessLocation)
        {
            _epcisEvent.BusinessLocation = businessLocation;
        }

        public void AddSourceDestinations(params SourceDestination[] sourceDests)
        {
            _epcisEvent.SourceDestinationList.AddRange(sourceDests);
        }
    }
}
