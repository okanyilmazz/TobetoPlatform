using System;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators;

    public class UpdateQuestionTypeRequestValidator : AbstractValidator<UpdateQuestionTypeRequest>
    {
        public UpdateQuestionTypeRequestValidator()
        {
            RuleFor(qt => qt.Name).NotEmpty();

        }

    }



