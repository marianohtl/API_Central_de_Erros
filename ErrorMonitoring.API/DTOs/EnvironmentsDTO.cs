using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorMonitoring.API.DTOs
{
    public class EnvironmentsDTO
    {
        public int Id { get; set; }
        public string EName { get; set; }

        public virtual ICollection<ProjectsEnvironmentsDTO> ProjectsEnvironments { get; set; }
    }
}
