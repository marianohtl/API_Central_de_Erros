using ErrorMonitoring.Dominio.Entidades;
using ErrorMonitoring.Dominio.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace ErrorMonitoring.Dominio.Services
{
    public class LogsService : ILogsService
    {
        private readonly ILogsRepository _logsRepository;
        public LogsService(ILogsRepository logsRepository)
        {
            _logsRepository = logsRepository;
        }

        public IList<Logs> Logs()
        {
            try
            {
                return _logsRepository.Get().ToList();
            }
            catch
            {
                return new List<Logs>();
            }
        }

        public Logs LogsById(int ID)
        {
            try
            {
                return _logsRepository.GetById(ID);
            }
            catch
            {
                return null;
            }
        }

        public Logs Salvar(Logs logs)
        {
            try
            {
                return _logsRepository.Save(logs);
            }
            catch
            {
                return null;
            }
        }

        public Logs Atualizar(Logs logs)
        {
            try
            {
                return _logsRepository.Update(logs);
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
                return _logsRepository.Delete(ID);
            }
            catch
            {
                return false;
            }
        }
    }
}
