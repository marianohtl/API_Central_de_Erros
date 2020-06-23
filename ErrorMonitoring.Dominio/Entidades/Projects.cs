using System;
using System.Collections.Generic;

namespace ErrorMonitoring.Infra.Data.Domains
{
    public partial class Projects
    {
        public Projects()
        {
            Logs = new HashSet<Logs>();
            ProjectsEnvironments = new HashSet<ProjectsEnvironments>();
        }

        public int Id { get; set; }
        public string PName { get; set; }
        public bool? IsMobile { get; set; }
        public bool? IsWeb { get; set; }
        public bool? IsDesktop { get; set; }

        public virtual ICollection<Logs> Logs { get; set; }
        public virtual ICollection<ProjectsEnvironments> ProjectsEnvironments { get; set; }
    }
}
