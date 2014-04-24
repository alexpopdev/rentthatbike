using RentThatBike.Web.ServiceModel.Types;
using ServiceStack.FluentValidation;

namespace RentThatBike.Web.ServiceModel
{
    public class PutBicycleValidator : AbstractValidator<PutBicycle>
    {
        public PutBicycleValidator(BicycleValidator bicycleValidator)
        {
            RuleFor(r => r.Id).Must((r,id) => id == r.Bicycle.Id).WithMessage("There is a mismatch between the bicycle id from the URL and the one from the request body !");
            RuleFor(r => r.Bicycle).SetValidator(bicycleValidator);
        }
    }
}