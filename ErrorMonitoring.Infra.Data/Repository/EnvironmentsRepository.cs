using ErrorMonitoring.Dominio.Entidades;
using ErrorMonitoring.Dominio.Interfaces;
using ErrorMonitoring.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ErrorMonitoring.Infra.Data.Repository
{
    public class EnvironmentsRepository : IEnvironmentsRepository
    {
        private readonly ApiContext _apiContext;
        public EnvironmentsRepository(ApiContext apiContext)
        {
            this._apiContext = apiContext;
        }

        public IEnumerable<Environments> Get()
        {
            return _apiContext.Environments;
        }

        public Environments GetById(int id)
        {
            return _apiContext.Environments.Where(x => x.Id == id).FirstOrDefault();
        }

        public Environments Save(Environments environment)
        {
            var state = environment.Id == 0 ? EntityState.Added : EntityState.Modified;
            _apiContext.Entry(environment).State = state;
            _apiContext.Add(environment);
            _apiContext.SaveChanges();
            return environment;
        }

        public Environments Update(Environments environment)
        {
            var _environment = _apiContext.Environments.Where(x => x.Id == environment.Id).FirstOrDefault();
            if (_environment != null)
            {
                _environment.EName = environment.EName;
                _apiContext.Entry(_environment).State = EntityState.Modified;
                _apiContext.SaveChanges();
            }
            return _environment;

        }

        public bool Delete(int id)
        {
            var _environment = _apiContext.Environments.Where(x => x.Id == id).FirstOrDefault();
            if (_environment != null)
            {
                _apiContext.Entry(_environment).State = EntityState.Deleted;
                _apiContext.SaveChanges();
                return true;
            }
            return false;
        }
    }
}
