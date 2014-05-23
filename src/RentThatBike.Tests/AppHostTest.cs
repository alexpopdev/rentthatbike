using Funq;
using RentThatBike.Web;
using ServiceStack.Common.Web;
using ServiceStack.WebHost.Endpoints;

namespace RentThatBike.Tests
{
    public class AppHostTest : AppHostHttpListenerBase
    {
        public AppHostTest()
            : base("Rent That Bike! Web services Test", typeof(AppHost).Assembly)
        {
        }

        public override void Configure(Container container)
        {
            SetConfig(CreateEndpointHostConfig());

            var appHostConfiguration = new AppHostConfiguration(this);
            appHostConfiguration.ConfigureAppHost(container, useTestDatabase: true);
        }

        private EndpointHostConfig CreateEndpointHostConfig()
        {
            return new EndpointHostConfig
            {
                DebugMode = true,
                DefaultContentType = ContentType.Json,
            };
        }
    }
}