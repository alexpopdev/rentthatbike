using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RentThatBike.Web.ServiceModel.Types;
using Xunit;

namespace RentThatBike.Tests
{
    public class BicycleTests
    {
        [Fact]
        public void TypeNameIsFormatted()
        {
            var bicycle = new Bicycle
            {
                Type = BicycleTypes.MountainBike
            };  

            Assert.Equal("Mountain Bike", bicycle.TypeName);
        }
    }
}
