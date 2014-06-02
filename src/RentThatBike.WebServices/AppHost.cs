using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Funq;
using ServiceStack.Common.Web;
using ServiceStack.WebHost.Endpoints;

namespace RentThatBike.WebServices
{
    public class AppHost : AppHostBase
    {
        public AppHost()
            : base("Rent That Bike! Remote web services", typeof(AppHost).Assembly)
        {
        }


        public override void Configure(Container container)
        {
        }
    }
}