using ErrorMonitoring.Dominio.Entidades;
using ErrorMonitoring.Dominio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ErrorMonitoring.Dominio.Services
{
    public class ProjectsService : IProjectsService
    {
        private readonly IProjectsRepository _projectsRepository;
        public ProjectsService(IProjectsRepository projectsRepository)
        {
            _projectsRepository = projectsRepository;
        }

        public IList<Projects> Projects()
        {
            try
            {
                return _projectsRepository.Get().ToList();
            }
            catch
            {
                return new List<Projects>();
            }
        }

        public Projects ProjectsById(int ID)
        {
            try
            {
                return _projectsRepository.GetById(ID);
            }
            catch
            {
                return null;
            }
        }

        public Projects Salvar(Projects projects)
        {
            try
            {
                return _projectsRepository.Save(projects);
            }
            catch
            {
                return null;
            }
        }

        public Projects Atualizar(Projects projects)
        {
            try
            {
                return _projectsRepository.Update(projects);
            }
            catch
            {
                return null;
            }
        }

        public bool Deletar(int ID)
        {
            try
            {
                return _projectsRepository.Delete(ID);
            }
            catch
            {
                return false;
            }
        }
    }
}