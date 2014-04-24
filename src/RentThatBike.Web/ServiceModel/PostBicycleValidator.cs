using RentThatBike.Web.ServiceModel.Types;
using ServiceStack.FluentValidation;

namespace RentThatBike.Web.ServiceModel
{
    public class PostBicycleValidator : AbstractValidator<PostBicycle>
    {
        public PostBicycleValidator(BicycleValidator BicycleValidator)
        {
            RuleFor(r => r.Bicycle).SetValidator(BicycleValidator);
        }
    }
}