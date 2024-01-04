using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators
{
    public class UpdateEducationProgramRequestValidator : AbstractValidator<UpdateEducationProgramRequest>
    {
        public UpdateEducationProgramRequestValidator()
        {
            RuleFor(e => e.Name).NotEmpty();

            RuleFor(e => e.Name).MinimumLength(2);
        }
    }
}
