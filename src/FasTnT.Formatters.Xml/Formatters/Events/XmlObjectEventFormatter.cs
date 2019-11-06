﻿using FasTnT.Formatters.Xml.Responses;
using FasTnT.Model;
using FasTnT.Model.Events.Enums;
using System.Linq;
using System.Xml.Linq;

namespace FasTnT.Formatters.Xml.Formatters.Events
{
    public class XmlObjectEventFormatter
    {
        private XElement _root;
        private XElement _extension = new XElement("extension");

        public XElement Process(EpcisEvent objectEvent)
        {
            _root = XmlEventFormatter.CreateEvent("ObjectEvent", objectEvent);

            AddEpcList(objectEvent);
            AddAction(objectEvent);
            AddBusinessStep(objectEvent);
            AddDisposition(objectEvent);
            AddReadPoint(objectEvent);
            AddBusinessLocation(objectEvent);
            AddBusinessTransactions(objectEvent);
            AddEventExtension(objectEvent);
            AddSourceDestinations(objectEvent);
            AddIlmdFields(objectEvent);
            AddExtensionField();
            AddCustomFields(objectEvent);

            return _root;
        }

        private void AddCustomFields(EpcisEvent evt)
        {
            _root.AddIfAny(XmlEventFormatter.GenerateCustomFields(evt, FieldType.CustomField));
        }

        private void AddExtensionField()
        {
            _root.AddIfNotNull(_extension);
        }

        private void AddEpcList(EpcisEvent objectEvent)
        {
            var inputEpcList = new XElement("inputEPCList", objectEvent.Epcs.Where(x => x.Type == EpcType.InputEpc).Select(e => new XElement("epc", e.Id)));
            var quantityList = new XElement("quantityList", objectEvent.Epcs.Where(x => x.Type == EpcType.Quantity).Select(XmlEventFormatter.FormatQuantity));

            _root.Add(new XElement("epcList", objectEvent.Epcs.Where(x => x.Type == EpcType.List).Select(e => new XElement("epc", e.Id))));
            if (inputEpcList.HasElements) _root.Add(inputEpcList);
            if (quantityList.HasElements) _extension.Add(quantityList);
        }

        private void AddAction(EpcisEvent objectEvent)
        {
            _root.Add(new XElement("action", objectEvent.Action.DisplayName));
        }

        private void AddBusinessStep(EpcisEvent evt)
        {
            _root.AddIfNotNull(XmlEventFormatter.GenerateBusinesStep(evt));
        }

        public void AddDisposition(EpcisEvent evt)
        {
            _root.AddIfNotNull(XmlEventFormatter.GenerateDisposition(evt));
        }
        private void AddReadPoint(EpcisEvent evt)
        {
            _root.AddIfNotNull(XmlEventFormatter.GenerateReadPoint(evt));
        }

        private void AddBusinessLocation(EpcisEvent evt)
        {
            _root.AddIfNotNull(XmlEventFormatter.GenerateBusinessLocation(evt));
        }

        private void AddBusinessTransactions(EpcisEvent evt)
        {
            _root.AddIfNotNull(XmlEventFormatter.GenerateBusinessTransactions(evt));
        }

        private void AddIlmdFields(EpcisEvent evt)
        {
            _extension.AddIfAny(XmlEventFormatter.GenerateCustomFields(evt, FieldType.Ilmd));
        }

        private void AddSourceDestinations(EpcisEvent evt)
        {
            _extension.AddIfAny(XmlEventFormatter.GenerateSourceDest(evt));
        }

        public void AddEventExtension(EpcisEvent evt)
        {
            var extension = new XElement("extension", XmlEventFormatter.GenerateCustomFields(evt, FieldType.EventExtension));
            _extension.AddIfNotNull(extension);
        }
    }
}
