using RentThatBike.Web.ServiceModel.Types;
using ServiceStack.FluentValidation;

namespace RentThatBike.Web.ServiceModel
{
    public class PostBicycleRequestValidator : AbstractValidator<PostBicycleRequest>
    {
        public PostBicycleRequestValidator(BicycleValidator BicycleValidator)
        {
            RuleFor(r => r.Bicycle).SetValidator(BicycleValidator);
        }
    }
}