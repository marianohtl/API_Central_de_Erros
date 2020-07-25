using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorMonitoring.API.DTOs
{
    public class EventsDTO
    {
        public int Id { get; set; }
        public string EStatus { get; set; }
        public string ELevel { get; set; }
        public string EOrigin { get; set; }
        public DateTime EDate { get; set; }
        public string EMessage { get; set; }
        public string EDescription { get; set; }
        public string EException { get; set; }
        public string EColectedBy { get; set; }


        public virtual ICollection<LogsDTO> Logs { get; set; }
}
}
