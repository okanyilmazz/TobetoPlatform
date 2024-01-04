using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators
{
    public class UpdateSocialMediaRequestValidator : AbstractValidator<UpdateSocialMediaRequest>
    {
        public UpdateSocialMediaRequestValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
            RuleFor(s => s.IconPath).NotEmpty();
        }
    }
}
