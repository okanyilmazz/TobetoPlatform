using Business.Dtos.Requests.BlogRequests;
using Business.Dtos.Requests.InstructorRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.InstructorValidators
{
    public class CreateInstructorRequestValidator : AbstractValidator<CreateInstructorRequest>
    {
        public CreateInstructorRequestValidator()
        {
            RuleFor(i =>i.UserId).NotEmpty();
        }
    }
}
