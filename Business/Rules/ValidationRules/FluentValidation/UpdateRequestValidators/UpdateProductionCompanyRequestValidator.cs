using System;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;

namespace Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators;

	public class UpdateProductionCompanyRequestValidator: AbstractValidator<UpdateProductionCompanyRequest>
    {

        public UpdateProductionCompanyRequestValidator()
        {
            RuleFor(pc => pc.Name).NotEmpty();

        }

   
    }

