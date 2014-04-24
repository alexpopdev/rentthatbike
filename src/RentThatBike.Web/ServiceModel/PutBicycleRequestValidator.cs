using RentThatBike.Web.ServiceModel.Types;
using ServiceStack.FluentValidation;

namespace RentThatBike.Web.ServiceModel
{
    public class PutBicycleRequestValidator : AbstractValidator<PutBicycleRequest>
    {
        public PutBicycleRequestValidator(BicycleValidator bicycleValidator)
        {
            RuleFor(r => r.Bicycle).SetValidator(bicycleValidator);
        }
    }
}