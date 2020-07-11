using ErrorMonitoring.Dominio.Entidades;
using ErrorMonitoring.Dominio.Interfaces;
using ErrorMonitoring.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErrorMonitoring.Infra.Data.Repository
{
    public class ProjectsEnvironmentsRepository: IProjectsEnvironmentsRepository
    {
        private readonly ApiContext _apiContext;
        public ProjectsEnvironmentsRepository(ApiContext apiContext)
        {
            this._apiContext = apiContext;
        }

        public IEnumerable<ProjectsEnvironments> Get()
        {
            return _apiContext.ProjectsEnvironments;
        }

        public ProjectsEnvironments GetById(int id)
        {
            return _apiContext.ProjectsEnvironments.Where(x => x.Id == id).FirstOrDefault();
        }

        public ProjectsEnvironments Save(ProjectsEnvironments projectsenvironment)
        {
            var state = projectsenvironment.Id == 0 ? EntityState.Added : EntityState.Modified;
            _apiContext.Entry(projectsenvironment).State = state;
            _apiContext.Add(projectsenvironment);
            _apiContext.SaveChanges();
            return projectsenvironment;
        }

        public ProjectsEnvironments Update(ProjectsEnvironments projectsenvironment)
        {
            var _projectsenvironment = _apiContext.ProjectsEnvironments.Where(x => x.Id == projectsenvironment.Id).FirstOrDefault();
            if (_projectsenvironment != null)
            {
                _projectsenvironment.Environment = projectsenvironment.Environment;
                _apiContext.Entry(_projectsenvironment).State = EntityState.Modified;
                _apiContext.SaveChanges();
            }
            return _projectsenvironment;

        }

        public bool Delete(int id)
        {
            var _projectsenvironment = _apiContext.ProjectsEnvironments.Where(x => x.Id == id).FirstOrDefault();
            if (_projectsenvironment != null)
            {
                _apiContext.Entry(_projectsenvironment).State = EntityState.Deleted;
                _apiContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
