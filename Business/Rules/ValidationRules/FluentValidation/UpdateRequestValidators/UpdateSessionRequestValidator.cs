using System;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;

public class UpdateSessionRequestValidator : AbstractValidator<UpdateSessionRequest>
{
    public UpdateSessionRequestValidator()
    {

        RuleFor(s => s.StartDate).NotEmpty();
        RuleFor(s => s.EndDate).NotEmpty();
        RuleFor(s => s.StartDate).LessThan(s => s.EndDate);
        RuleFor(s => s.RecordPath).NotEmpty();

    }
}

