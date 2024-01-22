using Business.Dtos.Requests.AccountHomeworkRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.AccountHomeworkValidators
{
    public class UpdateAccountHomeworkRequestValidator : AbstractValidator<UpdateAccountHomeworkRequest>
    {
        public UpdateAccountHomeworkRequestValidator()
        {
            RuleFor(ah => ah.Status).NotEmpty();
        }
    }
}
