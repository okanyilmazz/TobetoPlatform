using Business.Dtos.Requests.CreateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators
{
    public class CreateLessonSubjectRequestValidator : AbstractValidator<CreateLessonSubjectRequest>
    {
        public CreateLessonSubjectRequestValidator()
        {
            RuleFor(ls => ls.Name).NotEmpty();
        }
    }
}
