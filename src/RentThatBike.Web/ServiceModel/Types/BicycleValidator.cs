using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ServiceStack.FluentValidation;
using ServiceStack.FluentValidation.Results;
using ServiceStack;

namespace RentThatBike.Web.ServiceModel.Types
{
    public class BicycleValidator : AbstractValidator<Bicycle>
    {
        public BicycleValidator(IBicyleRepository bicyleRepository)
        {
            RuleFor(b => b.Name).NotEmpty();
            RuleFor(b => b.Quantity).GreaterThan(0);
            RuleFor(b => b.RentPrice).GreaterThan(0);

            RuleSet(ApplyTo.Post, () =>
            {
                RuleFor(b => b.Id).Equal(0);
                Custom(b =>
                {
                    bool bicycleWithSameNameExists =
                        bicyleRepository.Get(x => x.Name.ToLower() == b.Name.ToLower()).Any();
                    if (bicycleWithSameNameExists)
                    {
                        return new ValidationFailure("Name", "A bicycle with the same name already exists.",
                            "AlreadyExists");
                    }
                    return null;
                });
            });

            RuleSet(ApplyTo.Put, () =>
            {
                RuleFor(b => b.Id).GreaterThan(0);
                Custom(b =>
                {
                    bool bicycleWithSameNameExists =
                        bicyleRepository.Get(x => x.Name.ToLower() == b.Name.ToLower() && x.Id != b.Id).Any();
                    if (bicycleWithSameNameExists)
                    {
                        return new ValidationFailure("Name", "A bicycle with the same name already exists.",
                            "AlreadyExists");
                    }
                    return null;
                });
            });
        }
    }
}