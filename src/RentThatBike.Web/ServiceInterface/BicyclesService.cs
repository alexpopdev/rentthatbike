using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using RentThatBike.Web.ServiceModel;
using RentThatBike.Web.ServiceModel.Types;
using ServiceStack.ServiceHost;
using ServiceStack.ServiceInterface;

namespace RentThatBike.Web.ServiceInterface
{
    [Authenticate]
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

        public Bicycle Post(Bicycle request)
        {
            BicyleRepository.Add(request);
            return request;
        }

        public Bicycle Put(Bicycle request)
        {
            return BicyleRepository.Update(request);
        }
    }
}