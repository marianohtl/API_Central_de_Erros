using ErrorMonitoring.Dominio.Entidades;
using ErrorMonitoring.Dominio.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ErrorMonitoring.Dominio.Services
{
    public class EnvironmentsService:IEnvironmentsService
    {
        private readonly IEnvironmentsRepository _environmentsRepository;

        public EnvironmentsService(IEnvironmentsRepository environmentsRepository)
        {
            this._environmentsRepository = environmentsRepository;
        }
        public IList<Environments> Environments()
        {
            try
            {
                return _environmentsRepository.Get().ToList();
            }
            catch
            {
                return new List<Environments>();
            }
           
        }

        public Environments GetById(int id)
        {
            try
            {
                return _environmentsRepository.GetById(id);
            }
            catch
            {
                return null;
            }
            
        }

        public Environments Save(Environments environment)
        {
            try
            {
                return _environmentsRepository.Save(environment);
            }
            catch
            {
                return null;
            }

        }

        public Environments Update(Environments environment)
        {
            try
            {
                return _environmentsRepository.Update(environment);
            }
            catch
            {
                return null;
            }
        }

        public bool Delete (int id)
        {
            try
            {
                return _environmentsRepository.Delete(id);
            }
            catch
            {
                return false;
            }
        }
    }
}
