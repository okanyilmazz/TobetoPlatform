using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators
{
    public class UpdateLessonModuleRequestValidator : AbstractValidator<UpdateLessonModuleRequest>
    {
        public UpdateLessonModuleRequestValidator()
        {
            RuleFor(lm => lm.Name).NotEmpty();
        }
    }
}
