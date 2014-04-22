using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Funq;
using RentThatBike.Web.ServiceModel.Types;
using ServiceStack.WebHost.Endpoints;

namespace RentThatBike.Web
{
    public class AppHost: AppHostBase
    {
        public AppHost()
            : base("Rent That Bike! Web services", typeof(AppHost).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            container.RegisterAutoWired<BicyleRepository>();
        }
    }
}