﻿using FasTnT.Domain;
using FasTnT.Domain.Services.Handlers.PredefinedQueries;
using FasTnT.Model.Extensions;
using FasTnT.Model.Queries.Enums;
using FasTnT.Model.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace FasTnT.Model.Queries.Implementations
{
    public class SimpleEventQuery : IEpcisQuery
    {
        public string Name => "SimpleEventQuery";
        public bool AllowSubscription => true;

        public void ValidateParameters(IEnumerable<QueryParameter> parameters, bool subscription = false)
        {
            // TODO: raise exception if some parameter name/values are not valid.
        }

        public async Task<IEnumerable<EpcisEvent>> Execute(IEnumerable<QueryParameter> parameters, IEventRepository repository)
        {
            foreach(var parameter in parameters)
            {
                if (Equals(parameter.Name, "eventType")) repository.WhereEventTypeIn(parameter.Values);
                else if (Equals(parameter.Name, "EQ_action")) repository.WhereActionIn(parameter.Values.Select(Enumeration.GetByDisplayName<EventAction>).ToArray());
                else if (Equals(parameter.Name, "eventCountLimit")) repository.SetEventLimit(parameter.GetValue<int>());
                else if (Equals(parameter.Name, "maxEventCount")) repository.SetMaxEventCount(parameter.GetValue<int>());
                else if (Equals(parameter.Name, "EQ_bizLocation")) repository.WhereBusinessLocationIn(parameter.Values);
                else if (Equals(parameter.Name, "EQ_bizStep")) repository.WhereBusinessStepIn(parameter.Values);
                else if (Equals(parameter.Name, "EQ_disposition")) repository.WhereDispositionIn(parameter.Values);
                else if (Equals(parameter.Name, "EQ_eventID")) repository.WhereEventIdIn(parameter.Values);
                else if (Equals(parameter.Name, "EQ_transformationID")) repository.WhereTransformationIdIn(parameter.Values);
                else if (Equals(parameter.Name, "EXISTS_errorDeclaration")) repository.WhereExistsErrorDeclaration();
                else if (Equals(parameter.Name, "EQ_errorReason")) repository.WhereErrorReasonIn(parameter.Values);
                else if (Equals(parameter.Name, "EQ_correctiveEventID")) repository.WhereCorrectiveEventIdIn(parameter.Values);
                else if (Equals(parameter.Name, "MATCH_anyEPC")) repository.WhereEpcMatches(parameter.Values);

                // Regex-based parameters
                else if (Regex.IsMatch(parameter.Name, "^EQ_(source|destination)_")) ApplySourceDestinationParameter(parameter, repository);
                else if (Regex.IsMatch(parameter.Name, "^EQ_bizTransaction_")) ApplyBusinessTransactionParameter(parameter, repository);
                else if (Regex.IsMatch(parameter.Name, "^(GE|LT)_eventTime")) ApplyEventTimeParameter(parameter, repository);
                else if (Regex.IsMatch(parameter.Name, "^(GE|LT)_recordTime")) ApplyRecordTimeParameter(parameter, repository);
                else if (Regex.IsMatch(parameter.Name, "^MATCH_")) ApplyEpcMatchParameter(parameter, repository);
                else if (Regex.IsMatch(parameter.Name, "^(EQ|GT|LT|GE|LE)_quantity$")) ApplyQuantityParameter(parameter, repository);
                else if (Regex.IsMatch(parameter.Name, "^(EQ|GT|LT|GE|LE)_INNER_ILMD_")) ApplyIlmdParameter(parameter, true, repository);
                else if (Regex.IsMatch(parameter.Name, "^(EQ|GT|LT|GE|LE)_ILMD_")) ApplyIlmdParameter(parameter, false, repository);
                else if (Regex.IsMatch(parameter.Name, "^EXISTS_INNER_ILMD_0")) ApplyExistIlmdParameter(parameter, true, repository);
                else if (Regex.IsMatch(parameter.Name, "^EXISTS_ILMD_")) ApplyExistIlmdParameter(parameter, false, repository);
                else if (Regex.IsMatch(parameter.Name, "^(EQ|GT|LT|GE|LE)_INNER_")) ApplyCustomFieldParameter(parameter, true, repository);
                else if (Regex.IsMatch(parameter.Name, "^(EQ|GT|LT|GE|LE)_")) ApplyCustomFieldParameter(parameter, false, repository);
                else if (Regex.IsMatch(parameter.Name, "^EXISTS_INNER")) ApplyExistCustomFieldParameter(parameter, true, repository);
                else if (Regex.IsMatch(parameter.Name, "^EXISTS_")) ApplyExistCustomFieldParameter(parameter, false, repository);

                else throw new NotImplementedException($"Query parameter unexpected or not implemented: '{parameter.Name}'");
            }

            return await repository.ToList();
        }

        private void ApplyQuantityParameter(QueryParameter parameter, IEventRepository repository)
        {
            var filterOperator = Enumeration.GetByDisplayName<FilterOperator>(parameter.Name.Substring(0, 2));
            repository.WhereEpcQuantityMatches(filterOperator, parameter.GetValue<double>());
        }

        private void ApplyBusinessTransactionParameter(QueryParameter parameter, IEventRepository repository)
        {
            var txName = parameter.Name.Split('_', 3)[2];
            repository.WhereBusinessTransactionValueIn(txName, parameter.Values);
        }

        private void ApplySourceDestinationParameter(QueryParameter parameter, IEventRepository repository)
        {
            var name = parameter.Name.Split('_', 3)[2];

            if (parameter.Name.StartsWith("EQ_source_")) repository.WhereSourceValueIn(name, parameter.Values);
            else repository.WhereDestinationValueIn(name, parameter.Values);
        }

        private void ApplyExistCustomFieldParameter(QueryParameter parameter, bool inner, IEventRepository repository)
        {
            var parts = parameter.Name.Split('_', 4);
            repository.WhereExistsIlmd(inner, parts[2], parts[3]);
        }

        private void ApplyCustomFieldParameter(QueryParameter parameter, bool inner, IEventRepository repository)
        {
            throw new NotImplementedException();
        }

        private void ApplyExistIlmdParameter(QueryParameter parameter, bool inner, IEventRepository repository)
        {
            var parts = parameter.Name.Split('_', 4);
            repository.WhereExistsIlmd(inner, parts[2], parts[3]);
        }

        private void ApplyIlmdParameter(QueryParameter parameter, bool inner, IEventRepository repository)
        {
            throw new NotImplementedException();
        }

        private void ApplyEventTimeParameter(QueryParameter parameter, IEventRepository repository)
        {
            var filterOperator = Enumeration.GetByDisplayName<FilterOperator>(parameter.Name.Substring(0, 2));
            repository.WhereCaptureTimeMatches(filterOperator, parameter.GetValue<DateTime>());
        }

        private void ApplyRecordTimeParameter(QueryParameter parameter, IEventRepository repository)
        {
            var filterOperator = Enumeration.GetByDisplayName<FilterOperator>(parameter.Name.Substring(0, 2));
            repository.WhereRecordTimeMatches(filterOperator, parameter.GetValue<DateTime>());
        }

        private void ApplyEpcMatchParameter(QueryParameter parameter, IEventRepository repository)
        {
            var epcType = Enumeration.GetByDisplayName<EpcType>(parameter.Name.Substring(6));
            repository.WhereEpcMatches(parameter.Values, epcType);
        }
    }
}
