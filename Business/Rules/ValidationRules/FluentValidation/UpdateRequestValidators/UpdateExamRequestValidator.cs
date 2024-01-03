using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators;

public class UpdateExamRequestValidator : AbstractValidator<UpdateExamRequest>
{
    public UpdateExamRequestValidator()
    {
        RuleFor(eppl => eppl.Name).NotEmpty();
        RuleFor(eppl => eppl.Description).NotEmpty();
        RuleFor(eppl => eppl.Duration).NotEmpty();
        RuleFor(eppl => eppl.QuestionCount).NotEmpty();

        RuleFor(eppl => eppl.Name).MinimumLength(2);
        RuleFor(eppl => eppl.Description).MinimumLength(10);
    }
}
