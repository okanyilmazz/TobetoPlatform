using Business.Dtos.Requests.CreateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators
{
    public class CreateAccountUniversityRequestValidator : AbstractValidator<CreateAccountUniversityRequest>
    {
        public CreateAccountUniversityRequestValidator()
        {
            RuleFor(au => au.AccountId).NotEmpty();
            RuleFor(au => au.DegreeTypeId).NotEmpty();
            RuleFor(au => au.UniversityId).NotEmpty();
            RuleFor(au => au.UniversityDepartmentId).NotEmpty();
            RuleFor(au => au.StartDate).NotEmpty();
            RuleFor(au => au.IsEducationActive).NotEmpty();
        }
    }
}
