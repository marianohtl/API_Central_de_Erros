using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorMonitoring.Dominio.Entidades
{
    public class EventsFilter
    {
        public string Environment { get; set; }

        public string Level { get; set; }

        public string Origin { get; set; }

        public string Description { get; set; }

        public string OrderByName { get; set; }

        public string OrderByDirection { get; set; }

        public bool IsOrderAsc() => OrderByDirection?.Trim()?.ToLower() == "asc";
        public bool IsOrderDesc() => OrderByDirection?.Trim()?.ToLower() == "desc";
        
    }
}
