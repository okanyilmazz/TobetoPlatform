using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators
{
    public class UpdateAccountOccupationClassRequestValidator : AbstractValidator<UpdateAccountOccupationClassRequest>
    {
        public UpdateAccountOccupationClassRequestValidator()
        {
            RuleFor(a => a.AccountId).NotEmpty();
            RuleFor(a => a.OccupationClassId).NotEmpty();
        }
    }
}