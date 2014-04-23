using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentThatBike.Web.ServiceModel.Types;
using ServiceStack.ServiceHost;

namespace RentThatBike.Web.ServiceModel
{
    [Route("/bicycles/{Id}", "PUT")]
    public class PutBicycleRequest
    {
        public Bicycle Bicycle { get; set; }
    }
}