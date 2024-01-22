using Business.Dtos.Requests.OccupationClassRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.OccupationClassValidators
{
    public class CreateOccupationClassRequestValidator : AbstractValidator<CreateOccupationClassRequest>
    {
        public CreateOccupationClassRequestValidator()
        {
            RuleFor(o => o.Name).NotEmpty();
        }
    }
}
