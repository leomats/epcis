﻿using FasTnT.Formatters.Xml.Model.Events.Aggregation;
using FasTnT.Formatters.Xml.Model.Events.Object;
using FasTnT.Formatters.Xml.Model.Events.Quantity;
using FasTnT.Formatters.Xml.Model.Events.Transaction;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace FasTnT.Formatters.Xml.Model.Events
{

    public class XmlEventBody
    {
        // TODO: add EventListExtensionType
        [XmlArray("EventList")]
        [XmlArrayItem("ObjectEvent", typeof(ObjectEvent))]
        [XmlArrayItem("QuantityEvent", typeof(QuantityEvent))]
        [XmlArrayItem("TransactionEvent", typeof(TransactionEvent))]
        [XmlArrayItem("AggregationEvent", typeof(AggregationEvent))]
        public List<BaseEpcisEvent> EventList { get; set; }
    }
}