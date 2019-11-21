using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxTest.Models
{
    public class AjaxTestValid : AbstractValidator<AjaxTestModel>
    {
        public AjaxTestValid()
        {
            this.RuleFor(x => x.OptIn).NotEmpty().WithMessage("OptIn is Required");
            //this.RuleFor(x => x.Name).NotEmpty().WithMessage("Name is Required");
            //this.RuleFor(x => x.OptIn).NotNull().WithMessage("OptIn can not be null");
            this.RuleFor(x => x.Name).NotNull().WithMessage("Name can not be null");
        }
    }
}