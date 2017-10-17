using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using Funq;
using ServiceStack;
using ServiceStack.Common.Web;
using ServiceStack.ServiceInterface.Cors;
using ServiceStack.Text;
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
            SetConfig(new EndpointHostConfig
            {
                AllowJsonpRequests = true
            });
            
            JsConfig.EmitCamelCaseNames = true;
            JsConfig.DateHandler = JsonDateHandler.ISO8601;

            Plugins.Add(new CorsFeature());

            PreRequestFilters.Add((httpReq, httpRes) =>
            {
                if (httpReq.HttpMethod == "OPTIONS")
                    httpRes.EndRequest(); 
            });
        }
    }
}