using ErrorMonitoring.Dominio.Entidades;
using System.Collections.Generic;

namespace ErrorMonitoring.Dominio.Interfaces
{
    public interface ILogsRepository
    {
        IEnumerable<Logs> Get();
        Logs GetById(int Id);
        Logs Save(Logs logs);
        Logs Update(Logs logs);
        bool Delete(int Id);
    }
}
