using Business.Dtos.Requests.LessonSubjectRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.LessonSubjectValidators
{
    public class CreateLessonSubjectRequestValidator : AbstractValidator<CreateLessonSubjectRequest>
    {
        public CreateLessonSubjectRequestValidator()
        {
            RuleFor(ls => ls.Name).NotEmpty();
        }
    }
}
