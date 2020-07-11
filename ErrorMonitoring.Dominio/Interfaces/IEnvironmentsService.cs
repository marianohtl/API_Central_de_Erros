using ErrorMonitoring.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ErrorMonitoring.Dominio.Interfaces
{
    public interface IEnvironmentsService
    {
        IList<Environments> Environments();
        Environments GetById(int id);
        Environments Save(Environments environment);
        Environments Update(Environments environment);
        bool Delete (int id);
    }
}
