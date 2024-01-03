using Business.Dtos.Requests.CreateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators
{
    public class CreateAccountHomeworkRequestValidator : AbstractValidator<CreateAccountHomeworkRequest>
    {
        public CreateAccountHomeworkRequestValidator()
        {
            RuleFor(ah => ah.AccountId).NotEmpty();
            RuleFor(ah => ah.HomeworkId).NotEmpty();
            RuleFor(ah => ah.Status).NotEmpty();
        }
    }
}
