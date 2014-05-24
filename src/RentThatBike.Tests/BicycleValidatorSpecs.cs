using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using RentThatBike.Web.ServiceModel.Types;
using ServiceStack.FluentValidation.Results;
using Xbehave;
using Xunit;

namespace RentThatBike.Tests
{
    public class BicycleValidatorSpecs
    {
        [Scenario]
        public void ValidatesIncompleteBicycle()
        {
            Bicycle bicycle = null;
            ValidationResult validationResult = null;
            "Given an empty bicycle instance"
                .Given(() =>
                {
                    bicycle = new Bicycle();
                });
            "When is validated"
                .When(() =>
                {
                    IBicyleRepository bicyleRepository = Mock.Of<IBicyleRepository>();
                    var bicycleValidator = new BicycleValidator(bicyleRepository);
                    validationResult = bicycleValidator.Validate(bicycle);
                });
            "Then the bicycle is not valid"
                .Then(() =>
                {
                    Assert.False(validationResult.IsValid);
                });
            "And it has three validation errors"
                .Then(() =>
                {
                    Assert.Equal(3, validationResult.Errors.Count);
                });

        }
    }
}
