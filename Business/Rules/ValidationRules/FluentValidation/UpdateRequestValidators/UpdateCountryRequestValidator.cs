using Business.Dtos.Requests.UpdateRequests;
using Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators
{
    public class UpdateCountryRequestValidator : AbstractValidator<UpdateCountryRequest>
    {
        public UpdateCountryRequestValidator()
        {
            RuleFor(c => c.Name).NotEmpty();

            RuleFor(c => c.Name).MinimumLength(2);
        }
    }
}
