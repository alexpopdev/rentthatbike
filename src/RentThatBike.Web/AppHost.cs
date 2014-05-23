using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Funq;
using RentThatBike.Web.ServiceModel;
using ServiceStack.Common.Web;
using ServiceStack.Configuration;
using ServiceStack.MiniProfiler;
using ServiceStack.MiniProfiler.Data;
using ServiceStack.Mvc;
using ServiceStack.WebHost.Endpoints;

namespace RentThatBike.Web
{
    public class AppHost : AppHostBase
    {
        public AppHost()
            : base("Rent That Bike! Web services", typeof(AppHost).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            //ASP.NET MVC integration
            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));

            SetConfig(CreateEndpointHostConfig());

            var appHostConfiguration = new AppHostConfiguration(this);
            appHostConfiguration.ConfigureAppHost(container);
        }

        private EndpointHostConfig CreateEndpointHostConfig()
        {
            return new EndpointHostConfig
            {
                DebugMode = true,
                DefaultContentType = ContentType.Json,
                ServiceStackHandlerFactoryPath = "api"
            };
        }
    }
}