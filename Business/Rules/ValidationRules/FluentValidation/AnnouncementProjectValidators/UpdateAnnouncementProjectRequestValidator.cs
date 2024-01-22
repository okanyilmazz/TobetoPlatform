using Business.Dtos.Requests.AnnouncementProjectRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.AnnouncementProjectValidators
{
    public class UpdateAnnouncementProjectRequestValidator : AbstractValidator<UpdateAnnouncementProjectRequest>
    {
        public UpdateAnnouncementProjectRequestValidator()
        {
        }
    }
}
