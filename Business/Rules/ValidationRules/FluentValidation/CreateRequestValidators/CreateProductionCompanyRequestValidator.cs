using System;
using Business.Dtos.Requests.CreateRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators
{
    public class CreateProductionCompanyRequestValidator : AbstractValidator<CreateProductionCompanyRequest>
    {
        public CreateProductionCompanyRequestValidator()
        {
            RuleFor(pc => pc.Name).NotEmpty();

        }

    }

}