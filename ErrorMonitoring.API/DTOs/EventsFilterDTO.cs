using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorMonitoring.API.DTOs
{
    public class EventsFilterDTO
    {

        public string Environment { get; set; }
        
        public string Level { get; set; }

        public string Origin { get; set; }

        public string Description { get; set; }

        public string OrderByName { get; set; }

        public string OrderByDirection { get; set; }
    }
}
