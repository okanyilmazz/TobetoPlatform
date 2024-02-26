using Business.Dtos.Requests.ModuleRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.ModuleValidators;

public class CreateModuleRequestValidator : AbstractValidator<CreateModuleRequest>
{
    public CreateModuleRequestValidator()
    {
        RuleFor(m => m.Name).NotEmpty();
    }
}
