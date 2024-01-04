using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators
{
    public class CreateSkillRequestValidator : AbstractValidator<CreateSkillRequest>
    {
        public CreateSkillRequestValidator()
        {
            RuleFor(s => s.Name).NotEmpty();
        }
    }
}
