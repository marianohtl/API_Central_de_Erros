using ErrorMonitoring.Dominio.Entidades;
using ErrorMonitoring.Dominio.Interfaces;
using ErrorMonitoring.Infra.Data.Contexts;
using ErrorMonitoring.Infra.Data.QueryBuilder;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;


namespace ErrorMonitoring.Infra.Data.Repository
{
    public class EventsRepository : IEventsRepository
    {
        private readonly ApiContext context;
        public EventsRepository(ApiContext context)
        {
            this.context = context;
        }

        public IEnumerable<Events> GetBySearch(EventsFilter filter)
        {
            return new EventsFilterQueryBuilder(context.Events.AsQueryable(), filter).Build();   
        }

        public Events GetById(int Id)
        {
            return context.Events.Where(x => x.Id == Id).FirstOrDefault();
        }

        public Events Save(Events events)
        {
            var state = events.Id == 0 ? EntityState.Added : EntityState.Modified;
            context.Entry(events).State = state;
            context.Add(events);
            context.SaveChanges();
            return events;
        }

        public Events Update(Events events)
        {
            var _event = context.Events.Where(e => e.Id == events.Id).FirstOrDefault();
            if (_event != null)
            {
                _event.EStatus = events.EStatus;
                _event.ELevel = events.ELevel;
                _event.EOrigin = events.EOrigin;
                _event.EDate = events.EDate;
                _event.EMessage = events.EMessage;
                _event.EDescription = events.EDescription;
                _event.EException = events.EException;
                _event.EColectedBy = events.EColectedBy;
                context.Entry(_event).State = EntityState.Modified;
                context.SaveChanges();
            }
            return events;
        }

        public bool Delete(int Id)
        {
            var _event = context.Events.Where(e => e.Id == Id).FirstOrDefault();

            if (_event != null)
            {
                context.Entry(_event).State = EntityState.Deleted;
                context.SaveChanges();
                return true;
            }
            return false;
        }

    }
}
