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
    public class LogsRepository : ILogsRepository
    {
        private readonly ApiContext context;

        public LogsRepository(ApiContext context)
        {
            this.context = context;
        }

        public IEnumerable<Logs> Get()
        {
            return context.Logs;
        }

        public Logs GetById(int Id)
        {
            return context.Logs.Where(x => x.Id == Id).FirstOrDefault();
        }

        public Logs Save(Logs logs)
        {
            var state = logs.Id == 0 ? EntityState.Added : EntityState.Modified;
            context.Entry(logs).State = state;
            context.Add(logs);
            context.SaveChanges();
            return logs;
        }

        public Logs Update(Logs logs)
        {
            var _logs = context.Logs.Where(x => x.Id == logs.Id).FirstOrDefault();
            if (_logs != null)
            {
                _logs.Project = logs.Project;
                _logs.EventType = logs.EventType;
                _logs.Archived = logs.Archived;
                context.Entry(_logs).State = EntityState.Modified;
                context.SaveChanges();
            }
            return logs;
        }

        public bool Delete(int Id)
        {
            var _logs = context.Logs.Where(x => x.Id == Id).FirstOrDefault();

            if (_logs != null)
            {
                context.Entry(_logs).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
