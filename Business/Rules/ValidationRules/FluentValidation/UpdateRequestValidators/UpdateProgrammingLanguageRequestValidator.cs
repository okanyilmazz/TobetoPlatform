using System;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators
{
    public class UpdateProgrammingLanguageRequestValidator : AbstractValidator<UpdateProgrammingLanguageRequest>
    {
        public UpdateProgrammingLanguageRequestValidator()
        {
            RuleFor(pl => pl.Name).NotEmpty();

        }

    }
}

