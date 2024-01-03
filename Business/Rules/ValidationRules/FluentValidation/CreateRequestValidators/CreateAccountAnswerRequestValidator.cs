using Business.Dtos.Requests.CreateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators
{
    public class CreateAccountAnswerRequestValidator : AbstractValidator<CreateAccountAnswerRequest>
    {
        public CreateAccountAnswerRequestValidator()
        {
            RuleFor(a => a.AccountId).NotEmpty();
            RuleFor(a => a.QuestionId).NotEmpty();
            RuleFor(a => a.ExamId).NotEmpty();
            RuleFor(a => a.GivenAnswer).NotEmpty();
        }
    }
}
