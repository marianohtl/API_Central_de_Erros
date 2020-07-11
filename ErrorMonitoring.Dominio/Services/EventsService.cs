using ErrorMonitoring.Dominio.Entidades;
using ErrorMonitoring.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErrorMonitoring.Dominio.Services
{
    public class EventsService : IEventsService
    {
        public readonly IEventsRepository _eventsRepository;

        public EventsService(IEventsRepository eventsRepository)
        {
            _eventsRepository = eventsRepository;
        }

        public IList<Events> Events(EventsFilter eventsFilter)
        {
            try
            {
                return _eventsRepository.GetBySearch(eventsFilter).ToList();
            }
            catch
            {
                return new List<Events>();
            }
        }
        public Events EventById(int ID)
        {
            try
            {
                return _eventsRepository.GetById(ID);
            }
            catch
            {
                return null;
            }
        }

        public Events Salvar(Events events)
        {
            try
            {
                return _eventsRepository.Save(events);
            }
            catch
            {
                return null;
            }
        }
        public Events Atualizar(Events events)
        {
            try
            {
                return _eventsRepository.Update(events);
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
                return _eventsRepository.Delete(ID);
            }
            catch
            {
                return false;
            }
        }

    }
}
