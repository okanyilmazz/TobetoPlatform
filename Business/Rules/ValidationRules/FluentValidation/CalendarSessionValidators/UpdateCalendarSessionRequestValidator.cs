using Business.Dtos.Requests.CalendarSessionRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CalendarSessionValidators
{
    public class UpdateCalendarSessionRequestValidator : AbstractValidator<CreateCalendarSessionRequest>
    {
        public UpdateCalendarSessionRequestValidator()
        {
            RuleFor(c => c.SessionId).NotEmpty();
            RuleFor(c => c.UserId).NotEmpty();
        }
    }
}
