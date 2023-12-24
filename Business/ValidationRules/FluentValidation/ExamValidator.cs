using Business.Dtos.Requests.CreateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class ExamValidator : AbstractValidator<CreateExamRequest>
    {
        public ExamValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Description).MinimumLength(2);
        }
    }
}
