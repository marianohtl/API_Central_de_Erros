using ErrorMonitoring.Dominio.Entidades;
using System.Collections.Generic;


namespace ErrorMonitoring.Dominio.Interfaces
{
    public interface ILogsService
    {
        IList<Logs> Logs();
        Logs LogsById(int ID);
        Logs Salvar(Logs logs);
        Logs Atualizar(Logs logs);
        bool Deletar(int ID); 
    }
}
