using ErrorMonitoring.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorMonitoring.Dominio.Interfaces
{
    public interface IProjectsEnvironmentsRepository
    {
        IEnumerable<ProjectsEnvironments> Get();
        ProjectsEnvironments GetById(int id);
        ProjectsEnvironments Save(ProjectsEnvironments projectsEnvironment);
        ProjectsEnvironments Update(ProjectsEnvironments projectsEnvironment);
        bool Delete(int id);
    }
}
