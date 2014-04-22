using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace RentThatBike.Web.ServiceModel.Types
{
    public class BicyleRepository
    {
        private List<Bicycle> _bicycles = new List<Bicycle>()
        {
            new Bicycle { Id = 1, Name = "Very fast bike", Type = BicycleTypes.RoadBike, Quantity = 5, RentPrice = 15 },
            new Bicycle { Id = 2, Name = "Very springy bike", Type = BicycleTypes.MountainBike, Quantity = 20, RentPrice = 17 },
            new Bicycle { Id = 3, Name = "Very classy bike", Type = BicycleTypes.UrbanBike, Quantity = 20, RentPrice = 14 },
            new Bicycle { Id = 4, Name = "Very colorful bike", Type = BicycleTypes.ChildrenBike, Quantity = 20, RentPrice = 9 }
        };

        public IEnumerable<Bicycle> GetAll()
        {
            return _bicycles;
        }

        public Bicycle Single(Expression<Func<Bicycle, bool>> where)
        {
            return _bicycles.Single(where.Compile());
        }
    }
}