using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class UpdateAnnouncementRequestValidator : AbstractValidator<UpdateAnnouncementRequest>
    {
        public UpdateAnnouncementRequestValidator()
        {
            RuleFor(a => a.Title).MinimumLength(2);
            RuleFor(a => a.Title).NotEmpty();
            RuleFor(a => a.Description).MinimumLength(10);
            RuleFor(a => a.Description).NotEmpty();
            RuleFor(a => a.AnnouncementDate).NotEmpty();
        }
    }
}
