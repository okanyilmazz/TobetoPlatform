using Business.Dtos.Requests.CreateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators
{
    public class CreateAccountSkillRequestValidator : AbstractValidator<CreateAccountSkillRequest>
    {
        public CreateAccountSkillRequestValidator()
        {
            RuleFor(a => a.AccountId).NotEmpty();
            RuleFor(a => a.SkillId).NotEmpty();
        }
    }
}
