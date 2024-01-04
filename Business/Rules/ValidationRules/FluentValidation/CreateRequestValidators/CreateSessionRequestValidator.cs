
using FluentValidation;
using System;

namespace Business.Dtos.Requests.CreateRequests;

public class CreateSessionRequestValidator : AbstractValidator<CreateSessionRequest>
{
    public CreateSessionRequestValidator()
    {
        
        
        RuleFor(s => s.StartDate).NotEmpty();
        RuleFor(s => s.EndDate).NotEmpty();
        RuleFor(s => s.StartDate).LessThan(s => s.EndDate);
        RuleFor(s => s.RecordPath).NotEmpty();
           
    }
}
