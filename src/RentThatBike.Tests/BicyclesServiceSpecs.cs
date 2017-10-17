using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentThatBike.Web.ServiceModel;
using RentThatBike.Web.ServiceModel.Types;
using ServiceStack.OrmLite;
using ServiceStack.ServiceClient.Web;
using ServiceStack.ServiceInterface.Auth;
using Xbehave;
using Xunit;

namespace RentThatBike.Tests
{
    public class BicyclesServiceSpecs : TestsBase
    {
        [Scenario]
        public void GetBicyclesWithSeedData()
        {
            List<Bicycle> bicycles = null;
            "Given the seed data is created"
                .Given(() => { });

            "When a GET bicycles request is made using admin credentials"
                .When(() =>
                {
                    var restClient = new JsonServiceClient(BaseUrl);
                    
                    restClient.Send(new Auth
                    {
                        provider = CredentialsAuthProvider.Name,
                        UserName = "admin@rentthatbike.com",
                        Password = "admin",
                        RememberMe = true,
                    });

                    bicycles = restClient.Get(new GetBicycles());
                });

            "Then the response is not null."
                .Then(() =>
                {
                    Assert.NotNull(bicycles);
                });

            "And 4 bicycles are returned."
                .Then(() =>
                {
                    Assert.Equal(4, bicycles.Count);
                });
        }
    }
}
