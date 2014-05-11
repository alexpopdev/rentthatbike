using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using ServiceStack.OrmLite;

namespace RentThatBike.Web.ServiceModel.Types
{
    public class BicyleRepository : IDisposable
    {
        public IDbConnectionFactory DbConnectionFactory { get; set; }

        private IDbConnection _db;
        private IDbConnection Db
        {
            get { return _db ?? (_db = DbConnectionFactory.Open()); }
        }
        public IEnumerable<Bicycle> GetAll()
        {
            return Db.Select<Bicycle>();
        }

        public IEnumerable<Bicycle> Get(Expression<Func<Bicycle, bool>> condition)
        {
            return Db.Select<Bicycle>(condition);
        }

        public Bicycle Single(Expression<Func<Bicycle, bool>> condition)
        {
            return Db.Select<Bicycle>(condition).Single();
        }

        public void Add(Bicycle bicycle)
        {
            Db.Insert(bicycle);
            bicycle.Id = (int)Db.GetLastInsertId();
        }

        public void Dispose()
        {
            if (_db != null)
            {
                _db.Dispose();
            }
        }
    }
}