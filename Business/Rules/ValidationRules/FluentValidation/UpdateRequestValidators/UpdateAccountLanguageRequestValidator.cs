using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators
{
    public class UpdateAccountLanguageRequestValidator : AbstractValidator<UpdateAccountLanguageRequest>
    {
        public UpdateAccountLanguageRequestValidator()
        {
            RuleFor(al => al.AccountId).NotEmpty();
            RuleFor(al => al.LanguageId).NotEmpty();
            RuleFor(al => al.LanguageLevelId).NotEmpty();
        }
    }
}
