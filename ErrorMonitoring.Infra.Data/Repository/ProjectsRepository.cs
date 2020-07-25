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
    public class ProjectsRepository : IProjectsRepository
    {
        private readonly ApiContext context;

        public ProjectsRepository(ApiContext context)
        {
            this.context = context;
        }

        public IEnumerable<Projects> Get()
        {
            return context.Projects;
        }

        public Projects GetById(int Id)
        {
            return context.Projects.Where(x => x.Id == Id).FirstOrDefault();
        }

        public Projects Save(Projects projects)
        {
            var state = projects.Id == 0 ? EntityState.Added : EntityState.Modified;
            context.Entry(projects).State = state;
            context.Add(projects);
            context.SaveChanges();
            return projects;
        }

        public Projects Update(Projects projects)
        {
            var _projects = context.Projects.Where(x => x.Id == projects.Id).FirstOrDefault();
            if (_projects != null)
            {
                _projects.PName = projects.PName;
                _projects.IsMobile = projects.IsMobile;
                _projects.IsWeb = projects.IsWeb;
                _projects.IsDesktop = projects.IsDesktop;
                context.Entry(_projects).State = EntityState.Modified;
                context.SaveChanges();
            }
            return projects;
        }

        public bool Delete(int Id)
        {
            var _projects = context.Projects.Where(x => x.Id == Id).FirstOrDefault();

            if (_projects != null)
            {
                context.Entry(_projects).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}