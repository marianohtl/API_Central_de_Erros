using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ErrorMonitoring.API.DTOs
{
    public class ProjectsEnvironmentsDTO
    {
        public int Id { get; set; }
        public int Project { get; set; }
        public int Environment { get; set; }

        //public virtual Environments EnvironmentNavigation { get; set; }
        //public virtual Projects ProjectNavigation { get; set; }
    }
}
