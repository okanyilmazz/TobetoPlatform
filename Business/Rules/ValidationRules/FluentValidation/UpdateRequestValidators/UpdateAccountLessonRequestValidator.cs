﻿using Business.Dtos.Requests.UpdateRequests;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules.ValidationRules.FluentValidation.UpdateRequestValidators
{
    public class UpdateAccountLessonRequestValidator : AbstractValidator<UpdateAccountLessonRequest>
    {
        public UpdateAccountLessonRequestValidator()
        {
        }
    }
}
