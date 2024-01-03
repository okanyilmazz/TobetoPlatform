using Business.Dtos.Requests.CreateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators
{
    public class CreateAccountLanguageRequestValidator : AbstractValidator<CreateAccountLanguageRequest>
    {
        public CreateAccountLanguageRequestValidator()
        {
            RuleFor(al => al.AccountId).NotEmpty();
            RuleFor(al => al.LanguageId).NotEmpty();
            RuleFor(al => al.LanguageLevelId).NotEmpty();
        }
    }
}
