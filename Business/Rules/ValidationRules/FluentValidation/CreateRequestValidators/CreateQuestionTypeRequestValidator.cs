using System;
using Business.Dtos.Requests.CreateRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;

public class CreateQuestionTypeRequestValidator : AbstractValidator<CreateQuestionTypeRequest>
{
    public CreateQuestionTypeRequestValidator()
    {
        RuleFor(qt => qt.Name).NotEmpty();
       
    }

}

