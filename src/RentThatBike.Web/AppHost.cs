using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Funq;
using RentThatBike.Web.ServiceModel;
using ServiceStack;
using ServiceStack.Common;
using ServiceStack.Configuration;
using ServiceStack.MiniProfiler;
using ServiceStack.MiniProfiler.Data;
using ServiceStack.Mvc;
using ServiceStack.Host;

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

            SetConfig(CreateHostConfig());

            var appHostConfiguration = new AppHostConfiguration(this);
            appHostConfiguration.ConfigureAppHost(container);
        }

        private HostConfig CreateHostConfig()
        {
            return new HostConfig
            {
                DebugMode = true,
                HandlerFactoryPath = "api"
            };
        }
    }
}