using Business.Dtos.Requests.AccountHomeworkRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.AccountHomeworkValidators
{
    public class CreateAccountHomeworkRequestValidator : AbstractValidator<CreateAccountHomeworkRequest>
    {
        public CreateAccountHomeworkRequestValidator()
        {
            RuleFor(ah => ah.Status).NotEmpty();
        }
    }
}
