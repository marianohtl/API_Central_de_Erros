using ErrorMonitoring.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorMonitoring.Dominio.Interfaces
{
    public interface IEventsRepository
    {
        IEnumerable<Events> GetBySearch(EventsFilter eventsFilter);
        Events GetById(int Id);

        Events Save(Events events);

        Events Update(Events events);

        bool Delete(int Id);

    }
}
