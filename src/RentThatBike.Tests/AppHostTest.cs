using Funq;
using RentThatBike.Web;
using ServiceStack;
using ServiceStack.Common;
using ServiceStack.Host;

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

        private HostConfig CreateEndpointHostConfig()
        {
            return new HostConfig
            {
                DebugMode = true
            };
        }
    }
}