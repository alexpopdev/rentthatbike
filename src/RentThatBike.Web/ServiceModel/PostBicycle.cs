using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RentThatBike.Web.ServiceModel.Types;
using ServiceStack.ServiceHost;

namespace RentThatBike.Web.ServiceModel
{
    [Route("/bicycles", "POST")]
    public class PostBicycle : IReturn<Bicycle>
    {
        public Bicycle Bicycle { get; set; }
    }
}