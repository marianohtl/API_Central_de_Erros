using ErrorMonitoring.Dominio.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ErrorMonitoring.Infra.Data.QueryBuilder
{
    public class EventsFilterQueryBuilder
    {
        private IQueryable<Events> _queryable;
        private readonly EventsFilter _filter;

        public EventsFilterQueryBuilder(IQueryable<Events> queryable, EventsFilter filter)
        {
            _queryable = queryable;
            _filter = filter;
        }

        private void WhereByLevel()
        {
            if (!string.IsNullOrWhiteSpace(_filter.Level))
            {
                _queryable = _queryable.Where(x => x.ELevel == _filter.Level);
            }
        }

        private void WhereByDescription()
        {
            if (!string.IsNullOrWhiteSpace(_filter.Description))
            {
                _queryable = _queryable.Where(x => x.EDescription == _filter.Description);
            }
        }

        //private void WhereByEnvironment()
        //{
        //    if (!string.IsNullOrWhiteSpace(_filter.Environment))
        //    {
        //        _queryable = _queryable.Where(x => x.EProject == _filter.Description);
        //    }
        //}
        public IEnumerable<Events> Build()
        {
            WhereByLevel();
            WhereByDescription();
            OrderBy();
            return _queryable.AsEnumerable();
        }

        private void OrderBy()
        {
            if (string.IsNullOrWhiteSpace(_filter.OrderByName))
            {
                return;
            }

            Expression<Func<Events, object>> exp = GetOrderByFieldExpression(_filter.OrderByName);

            if (_filter.IsOrderDesc())
            {
                _queryable = _queryable.OrderByDescending(exp);
                return;
            }
            _queryable = _queryable.OrderBy(exp);
        }
        private Expression<Func<Events, object>> GetOrderByFieldExpression(string orderByField)
        {
            switch (orderByField.Trim().ToLower())
            {
                case "status": 
                    return x => x.EStatus;
                
                case "id":
                default: 
                    return x => x.Id;
            }

        }
    }
}
