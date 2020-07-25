using ErrorMonitoring.Dominio.Entidades;
using ErrorMonitoring.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErrorMonitoring.Dominio.Services
{

    public class ProjectsEnvironmentsService:IProjectsEnvironmentsService
    {
        private readonly IProjectsEnvironmentsRepository _projectsEnvironmentsRepository;

        public ProjectsEnvironmentsService(IProjectsEnvironmentsRepository projectsEnvironmentsRepository)
        {
            this._projectsEnvironmentsRepository = projectsEnvironmentsRepository;
        }
        public IList<ProjectsEnvironments> ProjectsEnvironments()
        {
            try
            {
                return _projectsEnvironmentsRepository.Get().ToList();
            }
            catch
            {
                return new List<ProjectsEnvironments>();
            }

        }

        public ProjectsEnvironments GetById(int id)
        {
            try
            {
                return _projectsEnvironmentsRepository.GetById(id);
            }
            catch
            {
                return null;
            }

        }

        public ProjectsEnvironments Save(ProjectsEnvironments projectsEnvironment)
        {
            try
            {
                return _projectsEnvironmentsRepository.Save(projectsEnvironment);
            }
            catch
            {
                return null;
            }

        }

        public ProjectsEnvironments Update(ProjectsEnvironments projectsenvironment)
        {
            try
            {
                return _projectsEnvironmentsRepository.Update(projectsenvironment);
            }
            catch
            {
                return null;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                return _projectsEnvironmentsRepository.Delete(id);
            }
            catch
            {
                return false;
            }
        }
    }
}
