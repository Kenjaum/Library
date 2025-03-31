using FluentValidation;
using Library.Application.Commands.CreateLoan;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Validators
{
    public class CreateLoanCommandValidator : AbstractValidator<CreateLoanCommand>
    {
        public CreateLoanCommandValidator()
        {
            RuleFor(l => l.IdUser)
                .NotEmpty()
                .NotNull()
                .WithMessage("IdUser is a mandatory field.");

            RuleFor(l => l.IdBook)
              .NotEmpty()
              .NotNull()
              .WithMessage("IdBook is a mandatory field.");

        }
    }
}
