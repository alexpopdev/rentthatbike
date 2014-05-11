using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using Funq;
using RentThatBike.Web.ServiceModel;
using RentThatBike.Web.ServiceModel.Types;
using ServiceStack.CacheAccess;
using ServiceStack.CacheAccess.Providers;
using ServiceStack.Common.Utils;
using ServiceStack.Common.Web;
using ServiceStack.Configuration;
using ServiceStack.MiniProfiler;
using ServiceStack.MiniProfiler.Data;
using ServiceStack.Mvc;
using ServiceStack.OrmLite;
using ServiceStack.ServiceInterface;
using ServiceStack.ServiceInterface.Auth;
using ServiceStack.ServiceInterface.Validation;
using ServiceStack.Text;
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
            //ASP.NET MVC integration
            ControllerBuilder.Current.SetControllerFactory(new FunqControllerFactory(container));
            
            SetConfig(CreateEndpointHostConfig());

            JsConfig.EmitCamelCaseNames = true;

            Plugins.Add(new ValidationFeature());
            container.RegisterValidators(typeof(AppHost).Assembly);

            container.Register<ICacheClient>(new MemoryCacheClient());
            container.RegisterAutoWired<BicyleRepository>();

            Plugins.Add(new AuthFeature(
            () => new AuthUserSession(),
            new IAuthProvider[] {
                    new CredentialsAuthProvider()
                }));

            container.Register<IDbConnectionFactory>(
                new OrmLiteConnectionFactory(
                    ConfigurationManager.ConnectionStrings["SqlLiteConnection"].ConnectionString.MapAbsolutePath(), 
                    SqliteDialect.Provider));
            
            container.Register<IUserAuthRepository>(c =>
                new OrmLiteAuthRepository(c.Resolve<IDbConnectionFactory>()));

            var userAuthRepository = (OrmLiteAuthRepository)container.Resolve<IUserAuthRepository>();
            userAuthRepository.CreateMissingTables();
            if (userAuthRepository.GetUserAuthByUserName("admin@rentthatbike.com") == null)
            {
                userAuthRepository.CreateUserAuth(
                    new UserAuth {Email = "admin@rentthatbike.com", DisplayName = "Admin User"}, "admin");
            }

            container.Register<IUserAuthRepository>(userAuthRepository);
        }

        protected virtual EndpointHostConfig CreateEndpointHostConfig()
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