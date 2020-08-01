using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorMonitoring.Dominio.Entidades
{
    public class EventsFilter
    {
        public string Project { get; set; }
        public string Environment { get; set; }

        public string Level { get; set; }

        public string Origin { get; set; }

        public string Description { get; set; }

        public string OrderByName { get; set; }

        public string OrderByDescending { get; set; }

        public string OrderBy { get; set; }
        

    }
}
