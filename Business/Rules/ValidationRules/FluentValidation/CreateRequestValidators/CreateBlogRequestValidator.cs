using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators
{
    public class CreateBlogRequestValidator : AbstractValidator<CreateBlogRequest>
    {
        public CreateBlogRequestValidator()
        {
            RuleFor(b => b.Title).NotEmpty();
            RuleFor(b => b.Description).NotEmpty();
            RuleFor(b => b.ReleaseDate).NotEmpty();
            RuleFor(b => b.ThumbnailPath).NotEmpty();

            RuleFor(b => b.Title).MinimumLength(2);
            RuleFor(b => b.Description).MinimumLength(2);
            RuleFor(b => b.ThumbnailPath).MinimumLength(2);
        }
    }
}
