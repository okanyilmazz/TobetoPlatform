using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators
{
    public class UpdateAccountSocialMediaRequestValidator : AbstractValidator<UpdateAccountSocialMediaRequest>
    {
        public UpdateAccountSocialMediaRequestValidator()
        {
            RuleFor(asm => asm.Url).NotEmpty();
            RuleFor(asm => asm.Url).MaximumLength(255);
        }
    }
}
