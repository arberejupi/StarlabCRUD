using FluentValidation;
using StarlabsCRUD.Model;

namespace StarlabsCRUD.Validator
{


    public class PersonDtoValidator : AbstractValidator<PersonDto>
    {
        public PersonDtoValidator()
        {
            RuleFor(person => person.Name).NotEmpty().WithMessage("Name is required.");
            RuleFor(person => person.Surname).NotEmpty().WithMessage("Surname is required.");
            RuleFor(person => person.Age).GreaterThan(0).WithMessage("Age must be greater than 0.");
        }
    }

}
