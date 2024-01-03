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
    public class UpdateAccountRequestValidator : AbstractValidator<UpdateAccountRequest>
    {
        public UpdateAccountRequestValidator()
        {
            RuleFor(a => a.AddressId).NotEmpty();
            RuleFor(a => a.UserId).NotEmpty();
            RuleFor(a => a.PhoneNumber).NotEmpty();
            RuleFor(a => a.PhoneNumber).MinimumLength(10);
            RuleFor(a => a.PhoneNumber).Matches("^[0-9]+$");
            RuleFor(a => a.NationalId).NotEmpty();
            RuleFor(a => a.NationalId).Length(11);
            RuleFor(a => a.BirthDate).NotEmpty();
            RuleFor(a => a.Description).NotEmpty();
            RuleFor(a => a.Description).MinimumLength(10);
        }
    }
}
