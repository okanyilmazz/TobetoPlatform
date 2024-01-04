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
    public class UpdateWorkExperienceRequestValidator : AbstractValidator<UpdateWorkExperienceRequest>
    {
        public UpdateWorkExperienceRequestValidator()
        {
            RuleFor(w => w.Industry).NotEmpty();
            RuleFor(w => w.CompanyName).NotEmpty();
            RuleFor(w => w.Department).NotEmpty();
            RuleFor(w => w.Description).NotEmpty();
            RuleFor(w => w.StartDate).NotEmpty();
            RuleFor(w => w.EndDate).NotEmpty();
        }
    }
}
