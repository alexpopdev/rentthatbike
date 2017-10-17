using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Linq.Expressions;
using ServiceStack.OrmLite;

namespace RentThatBike.Web.ServiceModel.Types
{
    public class BicyleRepository : IBicyleRepository, IDisposable
    {
        public IDbConnectionFactory DbConnectionFactory { get; set; }

        private IDbConnection _db;
        private IDbConnection Db
        {
            get { return _db ?? (_db = DbConnectionFactory.Open()); }
        }
        public List<Bicycle> GetAll()
        {
            return Db.Select<Bicycle>();
        }

        public List<Bicycle> Get(Expression<Func<Bicycle, bool>> condition)
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

        public Bicycle Update(Bicycle sourceBicycle)
        {
            Bicycle bicycle = Single(b => b.Id == sourceBicycle.Id);
            bicycle.Name = sourceBicycle.Name;
            bicycle.Type = sourceBicycle.Type;
            bicycle.Quantity = sourceBicycle.Quantity;
            bicycle.RentPrice = sourceBicycle.RentPrice;
            Db.Update(bicycle);
            return bicycle;
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