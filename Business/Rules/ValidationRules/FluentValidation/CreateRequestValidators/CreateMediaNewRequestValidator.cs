using Business.Dtos.Requests.CreateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators
{
    public class CreateMediaNewRequestValidator : AbstractValidator<CreateMediaNewRequest>
    {
        public CreateMediaNewRequestValidator()
        {
            RuleFor(m => m.Title).NotEmpty();
            RuleFor(m => m.Description).NotEmpty();
            RuleFor(m => m.Description).MinimumLength(10);
            RuleFor(m => m.ReleaseDate).NotEmpty();
            RuleFor(m => m.ThumbnailPath).NotEmpty();
        }
    }
}
