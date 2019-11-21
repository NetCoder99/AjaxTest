using FluentValidation;
using FluentValidation.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AjaxTest.Models
{
    [Validator(typeof(PersonValidator))]
    public class Person
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public int? Age { get; set; }
    }

    public class PersonValidator : AbstractValidator<Person>
    {
        public PersonValidator()
        {
            RuleFor(x => x.Id).NotNull().WithMessage("Id can not be null");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Name is required");
            RuleFor(x => x.Email).EmailAddress().WithMessage("Email was not valid")
                                 .NotEmpty().WithMessage("Email is required");
            RuleFor(x => x.Age).InclusiveBetween(18, 60);
        }
    }
}