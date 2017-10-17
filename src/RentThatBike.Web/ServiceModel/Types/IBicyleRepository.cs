using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace RentThatBike.Web.ServiceModel.Types
{
    public interface IBicyleRepository
    {
        List<Bicycle> GetAll();
        List<Bicycle> Get(Expression<Func<Bicycle, bool>> condition);
        Bicycle Single(Expression<Func<Bicycle, bool>> condition);
        void Add(Bicycle bicycle);
        Bicycle Update(Bicycle sourceBicycle);
    }
}