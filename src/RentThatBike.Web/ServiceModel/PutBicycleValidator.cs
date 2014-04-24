using RentThatBike.Web.ServiceModel.Types;
using ServiceStack.FluentValidation;

namespace RentThatBike.Web.ServiceModel
{
    public class PutBicycleValidator : AbstractValidator<PutBicycle>
    {
        public PutBicycleValidator(BicycleValidator bicycleValidator)
        {
            RuleFor(r => r.Bicycle).SetValidator(bicycleValidator);
        }
    }
}