using ErrorMonitoring.Dominio.Entidades;
using System.Collections.Generic;

namespace ErrorMonitoring.Dominio.Interfaces
{
    public interface IProjectsRepository
    {
        IEnumerable<Projects> Get();
        Projects GetById(int Id);
        Projects Save(Projects projects);
        Projects Update(Projects projects);
        bool Delete(int Id);
    }
}