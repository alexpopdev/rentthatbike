using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentThatBike.Web.ServiceModel;
using RentThatBike.Web.ServiceModel.Types;
using ServiceStack.ServiceHost;

namespace RentThatBike.Web.ServiceInterface
{
    public class BicyclesService : IService
    {
        public BicyleRepository BicyleRepository { get; set; }

        public List<Bicycle> Get(GetBicycles request)
        {
            return BicyleRepository.GetAll().ToList();
        }

        public Bicycle Get(GetBicycle request)
        {
            return BicyleRepository.Single(b => b.Id == request.Id);
        }

        public Bicycle Post(PostBicycle request)
        {
            BicyleRepository.Add(request.Bicycle);
            return request.Bicycle;
        }

        public Bicycle Put(PutBicycle request)
        {
            Bicycle bicycle = BicyleRepository.Single(b => b.Id == request.Id);
            bicycle.Name = request.Bicycle.Name;
            bicycle.Type = request.Bicycle.Type;
            bicycle.Quantity = request.Bicycle.Quantity;
            bicycle.RentPrice = request.Bicycle.RentPrice;
            return bicycle;
        }
    }
}