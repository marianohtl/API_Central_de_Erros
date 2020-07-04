using ErrorMonitoring.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorMonitoring.Dominio.Interfaces
{
    public interface IEventsService
    {
        IList<Events> Events();

        Events EventById(int ID);

        Events Salvar(Events events);

        Events Atualizar(Events events);
      
        bool Deletar(int ID);

    }
}
