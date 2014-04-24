using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.ServiceHost;

namespace RentThatBike.Web.ServiceModel.Types
{
    [Route("/bicycles", "POST")]
    [Route("/bicycles/{Id}", "PUT")]
    public class Bicycle : IReturn<Bicycle>
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public BicycleTypes Type { get; set; }

        public string TypeName
        {
            get
            {
                return Type.ToString().Replace("Bike", " Bike");
            }
        }

        public int Quantity { get; set; }

        public double RentPrice { get; set; }
    }
}