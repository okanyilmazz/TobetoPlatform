using System;
using Business.Dtos.Requests.CreateRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators
{
    public class CreateProgrammingLanguageRequestValidator : AbstractValidator<CreateProgrammingLanguageRequest>
    {
        public CreateProgrammingLanguageRequestValidator()
        {
            RuleFor(pl => pl.Name).NotEmpty();

        }

    }

}

