using FluentValidation;
using Library.Application.Commands.CreateUser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Library.Application.Validators
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(u => u.Name)
                .NotEmpty()
                .NotNull()
                .WithMessage("Name is a mandatory field.");

            RuleFor(u => u.Name)
                .MaximumLength(100)
                .WithMessage("Name's maximum length is around 100 characters.");

            RuleFor(p => p.Password)
               .Must(ValidPassword)
               .WithMessage("Password must contain at least 8 characters, a number," +
               "one uppercase letter, one lowercase letter and one special character.");

            RuleFor(u => u.Password)
                .MaximumLength(20)
                .WithMessage("Password's maximum length is around 20 characters.");

            RuleFor(u => u.Role)
                .MaximumLength(100)
                .WithMessage("Role's maximum length is around 100 characters.");

        }

        public bool ValidPassword(string password)
        {
            var regex = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[!*@#$%^&+=]).*$");

            return regex.IsMatch(password);
        }
    }
}
