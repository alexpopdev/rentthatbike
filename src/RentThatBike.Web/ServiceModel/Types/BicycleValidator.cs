using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.FluentValidation;
using ServiceStack.FluentValidation.Results;

namespace RentThatBike.Web.ServiceModel.Types
{
    public class BicycleValidator: AbstractValidator<Bicycle>
    {
        public BicycleValidator(BicyleRepository bicyleRepository)
        {
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.Quantity).GreaterThan(0);
            RuleFor(b => b.RentPrice).GreaterThan(0);
            Custom(b =>
            {
                bool bicycleWithSameNameExists = bicyleRepository.Get(x => x.Name.ToLower() == b.Name.ToLower()).Any();
                if (bicycleWithSameNameExists)
                {
                    return new ValidationFailure("Name","A bicycle with the same name already exists.", "AlreadyExists");
                }
                return null;
            });
        }
    }
}