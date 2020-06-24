using ErrorMonitoring.Infra.Data.Domains;
using System;
using System.Collections.Generic;

namespace ErrorMonitoring.Dominio.Entidades
{
    public class Environments
    {
        public Environments()
        {
            ProjectsEnvironments = new HashSet<ProjectsEnvironments>();

        
        }

        public int Id { get; set; }
        public string EName { get; set; }

        public virtual ICollection<ProjectsEnvironments> ProjectsEnvironments { get; set; }
    }
}
