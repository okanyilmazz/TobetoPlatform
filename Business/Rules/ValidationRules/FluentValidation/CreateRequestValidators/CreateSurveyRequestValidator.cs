using Business.Dtos.Requests.CreateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators
{
    public class CreateSurveyRequestValidator : AbstractValidator<CreateSurveyRequest>
    {
        public CreateSurveyRequestValidator()
        {
            RuleFor(s => s.Title).NotEmpty();
            RuleFor(s => s.Content).NotEmpty();
            RuleFor(s => s.ConnectionLink).NotEmpty();
            RuleFor(s => s.ConnectionLink).MaximumLength(255);
        }
    }
}
