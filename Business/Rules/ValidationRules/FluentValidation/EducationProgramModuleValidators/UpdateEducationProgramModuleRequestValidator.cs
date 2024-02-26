using Business.Dtos.Requests.EducationProgramModuleRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.EducationProgramModuleValidators;

public class UpdateEducationProgramModuleRequestValidator : AbstractValidator<UpdateEducationProgramModuleRequest>
{
    public UpdateEducationProgramModuleRequestValidator()
    {
        RuleFor(epl => epl.Id).NotEmpty();
        RuleFor(epl => epl.EducationProgramId).NotEmpty();
        RuleFor(epl => epl.ModuleId).NotEmpty();
    }
}
