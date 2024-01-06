using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators
{
    public class UpdateAccountUniversityRequestValidator : AbstractValidator<UpdateAccountUniversityRequest>
    {
        public UpdateAccountUniversityRequestValidator()
        {
            RuleFor(au => au.StartDate).NotEmpty();
            RuleFor(au => au.StartDate).LessThan(au => au.EndDate);
            RuleFor(au => au.IsEducationActive).NotEmpty();
        }
    }
}