using Business.Dtos.Requests.BlogRequests;
using Business.Dtos.Requests.CalendarSessionRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.CalendarSessionValidators
{
    public class CreateCalendarSessionRequestValidator : AbstractValidator<CreateCalendarSessionRequest>
    {
        public CreateCalendarSessionRequestValidator()
        {
            RuleFor(c => c.SessionId).NotEmpty();
            RuleFor(c => c.UserId).NotEmpty();

        }
    }
}
