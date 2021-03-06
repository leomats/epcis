﻿using FasTnT.Model.Enums;

namespace FasTnT.Domain.Data.Model.Filters
{
    public class SimpleParameterFilter<T>
    {
        public EpcisField Field { get; set; }
        public T[] Values { get; set; }
    }
}
