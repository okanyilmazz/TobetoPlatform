using Business.Dtos.Requests.InstructorRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.InstructorValidators
{
    public class UpdateInstructorRequestValidator : AbstractValidator<UpdateInstructorRequest>
    {
        public UpdateInstructorRequestValidator()
        {
            RuleFor(i => i.UserId).NotEmpty();
            RuleFor(i => i.Id).NotEmpty();
        }
    }
}
