using Business.Dtos.Requests.EducationProgramModuleRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.EducationProgramModuleValidators;

public class CreateEducationProgramModuleRequestValidator : AbstractValidator<CreateEducationProgramModuleRequest>
{
    public CreateEducationProgramModuleRequestValidator()
    {
        RuleFor(epl => epl.EducationProgramId).NotEmpty();
        RuleFor(epl => epl.ModuleId).NotEmpty();
    }
}