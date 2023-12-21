using Business.Dtos.Requests.CreateRequests;
using Entities.Concretes;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class SkillValidator : AbstractValidator<CreateSkillRequest>
    {
        public SkillValidator()
        {
            RuleFor(p => p.Name).NotEmpty();
            RuleFor(p => p.Name).MinimumLength(2);
            //RuleFor(p => p.).GreaterThan(0);
            //RuleFor(p => p.).GreaterThanOrEqualTo(10).When(p => p.== 1);
            //RuleFor(p => p.Name).Must(StartWithA).WithMessage("Skills must be start A char");
        }

        //private bool StartWithA(string arg)
        //{
        //    return arg.StartsWith("A");
        //}
    }
}