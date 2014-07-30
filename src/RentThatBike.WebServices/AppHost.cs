using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Funq;
using ServiceStack;
using ServiceStack.Common;
using ServiceStack.Web;
using ServiceStack.Text;
using ServiceStack.Host;

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
            SetConfig(new HostConfig
            {
                AllowJsonpRequests = true
            });
            
            JsConfig.EmitCamelCaseNames = true;
            JsConfig.DateHandler = DateHandler.ISO8601;

            Plugins.Add(new CorsFeature());

          
        }
    }
}