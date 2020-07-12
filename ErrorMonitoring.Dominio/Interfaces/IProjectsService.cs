using ErrorMonitoring.Dominio.Entidades;
using System.Collections.Generic;


namespace ErrorMonitoring.Dominio.Interfaces
{
    public interface IProjectsService
    {
        IList<Projects> Projects();
        Projects ProjectsById(int ID);
        Projects Salvar(Projects projects);
        Projects Atualizar(Projects projects);
        bool Deletar(int ID);
    }
}