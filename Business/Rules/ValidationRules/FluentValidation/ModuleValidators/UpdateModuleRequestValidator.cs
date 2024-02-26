using Business.Dtos.Requests.ModuleRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.ModuleValidators;

public class UpdateModuleRequestValidator : AbstractValidator<UpdateModuleRequest>
{
    public UpdateModuleRequestValidator()
    {
        RuleFor(m => m.Id).NotEmpty();
        RuleFor(m => m.Name).NotEmpty();
    }
}
