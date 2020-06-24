using ErrorMonitoring.Dominio.Entidades;
using System;
using System.Collections.Generic;

namespace ErrorMonitoring.Infra.Data.Domains
{
    public class ProjectsEnvironments
    {
        public int Id { get; set; }
        public int Project { get; set; }
        public int Environment { get; set; }

        public virtual Environments EnvironmentNavigation { get; set; }
        public virtual Projects ProjectNavigation { get; set; }
    }
}
