using FasTnT.Model.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using FasTnT.Parsers.Xml.Utils;
using FasTnT.Model.Events;

namespace FasTnT.Parsers.Xml.Capture
{
    public static class MISSING_PARSERS
    {
        // These parameters are still to be implemented as parsers
        private static readonly IDictionary<string, Action<EpcisEvent, XElement>> ParserMethods = new Dictionary<string, Action<EpcisEvent, XElement>>
        {
            //{ "childEPCs",           (evt, node) => node.ParseChildEpcListInto(evt) },
            //{ "inputQuantityList",   (evt, node) => node.ParseQuantityListInto(evt, EpcType.InputQuantity) },
            //{ "inputEPCList",        (evt, node) => node.ParseEpcListInto(EpcType.InputEpc, evt) },
            //{ "outputQuantityList",  (evt, node) => node.ParseQuantityListInto(evt, EpcType.OutputQuantity) },
            //{ "childQuantityList",   (evt, node) => node.ParseQuantityListInto(evt, EpcType.ChildQuantity) },
            //{ "epcClass",            (evt, node) => evt.Epcs.Add(new Epc { Type = EpcType.Quantity, Id = node.Value, IsQuantity = true }) },
            //{ "quantity",            (evt, node) => evt.Epcs.Single(x => x.Type == EpcType.Quantity).Quantity = float.Parse(node.Value, CultureInfo.InvariantCulture) },
            //{ "bizStep",             (evt, node) => evt.BusinessStep = node.Value },
            //{ "errorDeclaration",    (evt, node) => evt.ErrorDeclaration = node.ToErrorDeclaration(evt) },
            //{ "ilmd",                (evt, node) => ParseIlmd(node, evt) },
            //{ "recordTime",          (evt, node) => { } }, // We don't process record time as it will be overrided in any case..
            //{ "extension",           (evt, node) => ParseExtensionElement(node, evt) },
            //{ "baseExtension",       (evt, node) => ParseExtensionElement(node, evt) },
        };
    }
}
