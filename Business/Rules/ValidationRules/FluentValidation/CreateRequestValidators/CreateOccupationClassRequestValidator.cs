using Business.Dtos.Requests.CreateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators
{
    public class CreateOccupationClassRequestValidator : AbstractValidator<CreateOccupationClassRequest>
    {
        public CreateOccupationClassRequestValidator()
        {
            RuleFor(o=>o.Name).NotEmpty();
        }
    }
}
