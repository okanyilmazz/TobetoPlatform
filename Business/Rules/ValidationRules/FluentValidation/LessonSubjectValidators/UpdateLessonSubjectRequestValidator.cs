using Business.Dtos.Requests.LessonSubjectRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.LessonSubjectValidators;

public class UpdateLessonSubjectRequestValidator : AbstractValidator<UpdateLessonSubjectRequest>
{
    public UpdateLessonSubjectRequestValidator()
    {
        RuleFor(ls => ls.Name).NotEmpty();
    }
}
