using System;
using FasTnT.Model.Enums;
using FasTnT.Model.Events;

namespace FasTnT.Parsers.Xml.Capture
{
    public interface IEventBuilder
    {
        void SetEventTime(DateTime eventTime);
        void SetAction(EventAction action);
        void SetEventTimeZoneOffset(TimeZoneOffset timeZoneOffset);
        void AddBusinessTransactions(params BusinessTransaction[] businessTransactions);
        void AddEpcs(params Epc[] epcs);
        void SetBusinessStep(string businessStep);
        void SetDisposition(string disposition);
        void SetReadPoint(string readPoint);
        void AddCustomFields(params CustomField[] customFields);
        void SetEventId(string eventId);
        void SetTransformationId(string transformationId);
        void SetBusinessLocation(string businessLocation);
        void AddSourceDestinations(params SourceDestination[] sourceDests);
    }
}
