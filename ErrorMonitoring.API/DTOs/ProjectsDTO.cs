using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorMonitoring.API.DTOs
{
    public class ProjectsDTO
    {
        public int Id { get; set; }
        public string PName { get; set; }
        public bool? IsMobile { get; set; }
        public bool? IsWeb { get; set; }
        public bool? IsDesktop { get; set; }

        public virtual ICollection<LogsDTO> Logs { get; set; }
        public virtual ICollection<ProjectsEnvironmentsDTO> ProjectsEnvironments { get; set; }
    }
}
