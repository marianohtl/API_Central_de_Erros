using ErrorMonitoring.Dominio.Entidades;
using ErrorMonitoring.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ErrorMonitoring.Infra.Data.QueryBuilder
{

    public class EventsFilterQueryBuilder
    {
        private IQueryable<Events> _queryable;
        private readonly EventsFilter _filter;
        private readonly ApiContext context;

        public EventsFilterQueryBuilder(IQueryable<Events> queryable, EventsFilter filter, ApiContext context)
        {
            _queryable = queryable;
            _filter = filter;
            this.context = context;
        }

        public IEnumerable<Events> Build()
        {
            WhereByArchived();
            WhereByEnvironment();
            WhereByLevel();
            WhereByDescription();
            WhereByProjects();
            OrderBy();
            OrderByDescending();
            return _queryable.AsEnumerable();
        }
        private void WhereByArchived()
        {
            if ( string.IsNullOrWhiteSpace(_filter.Environment))
            {
                bool archived = false;
                if (!string.IsNullOrWhiteSpace(_filter.Archived))
                {
                    archived = _filter.Archived == "true" ? true : false;
                }
                var queryLogs = context.Logs.Where(x => x.Archived == archived).Select(y => y.Id);
                _queryable = _queryable.Where(x => queryLogs.Contains(x.Id));
            }
        }
        private void WhereByLevel()
        {
            if (!string.IsNullOrWhiteSpace(_filter.Level))
            {
                _queryable = _queryable.Where(x => x.ELevel == _filter.Level);
            }
        }

        private void WhereByDescription()
        {
            if (!string.IsNullOrWhiteSpace(_filter.Description))
            {
                _queryable = _queryable.Where(x => x.EDescription == _filter.Description);
            }
        }


        private void WhereByEnvironment()
        {
            if (!string.IsNullOrWhiteSpace(_filter.Environment))
            {
                Projects project;
                bool archived = false;
                if (!string.IsNullOrWhiteSpace(_filter.Project))
                {
                    project = context.Projects.Where(x => x.PName == _filter.Project).FirstOrDefault();
                }
                else
                {
                    project = context.Projects.FirstOrDefault();
                }

                if (!string.IsNullOrWhiteSpace(_filter.Archived))
                {
                    archived = _filter.Archived == "true" ? true : false;
                }

                var queryEnvironment = context.Environments.Where(x => x.EnvName == _filter.Environment).Select(x => x.Id);
                var projectsEnvironments = context.ProjectsEnvironments.Where(x => queryEnvironment.Contains(x.Environment) && project.Id == x.ProjectNavigation.Id).Select(x => x.Project);
                var queryLogs = context.Logs.Where(x => projectsEnvironments.Contains(x.Project) && x.Archived == archived).Select(x => x.EventType);
                _queryable = _queryable.Where(x => queryLogs.Contains(x.Id));
            }

        }

        private void WhereByProjects()
        {
            Projects project; 
            bool archived = false;

            if (string.IsNullOrWhiteSpace(_filter.Environment) && !string.IsNullOrWhiteSpace(_filter.Project))
            {
                project = context.Projects.Where(x => x.PName == _filter.Project).FirstOrDefault();
                
                if (!string.IsNullOrWhiteSpace(_filter.Archived))
                {
                    archived = _filter.Archived == "true" ? true : false;
                }
                var queryLogs = context.Logs.Where(x => x.Project== project.Id && x.Archived == archived).Select(x => x.EventType);
                _queryable = _queryable.Where(x => queryLogs.Contains(x.Id));
            }

        }

        private void OrderByDescending()
        {
            if (string.IsNullOrWhiteSpace(_filter.OrderByDescending))
            {
                return;
            }

            if (_filter.OrderByDescending.Trim().ToLower() == "level")
            {
                _queryable = _queryable.OrderByDescending(x => x.ELevel);
            }

        }
        private void OrderBy()
        {
            if (string.IsNullOrWhiteSpace(_filter.OrderBy))
            {
                //_queryable = _queryable.OrderBy(x => x.Id);
                return;
            }

            if (_filter.OrderBy.Trim().ToLower() == "level")
            {
                _queryable = _queryable.OrderBy(x => x.ELevel);
            }

        }

    }
}

