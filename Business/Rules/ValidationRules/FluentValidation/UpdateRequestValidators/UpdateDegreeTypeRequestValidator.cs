﻿using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators
{
    public class UpdateDegreeTypeRequestValidator : AbstractValidator<UpdateDegreeTypeRequest>
    {
        public UpdateDegreeTypeRequestValidator()
        {
            RuleFor(d => d.Name).NotEmpty();

            RuleFor(d => d.Name).MinimumLength(2);
        }
    }
}
