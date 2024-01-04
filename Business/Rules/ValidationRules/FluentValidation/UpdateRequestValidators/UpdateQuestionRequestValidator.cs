using System;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.CreateRequestValidators
{
    public class UpdateQuestionRequestValidator : AbstractValidator<UpdateQuestionRequest>
    {
      
            public UpdateQuestionRequestValidator()
            {

                RuleFor(q => q.Description).NotEmpty();
                RuleFor(q => q.OptionA).NotEmpty();
                RuleFor(q => q.OptionB).NotEmpty();
                RuleFor(q => q.OptionC).NotEmpty();
                RuleFor(q => q.OptionD).NotEmpty();
                RuleFor(q => q.CorrectOption).NotEmpty();
                RuleFor(q => q.Description).MinimumLength(10);
            }

        

    }

}

