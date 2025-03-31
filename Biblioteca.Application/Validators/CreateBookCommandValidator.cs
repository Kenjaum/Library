using FluentValidation;
using Library.Application.Commands.CreateBook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Validators
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            RuleFor(b => b.Title)
                .MaximumLength(254)
                .WithMessage("Title's maximum length is around 254 character.");

            RuleFor(b => b.Author)
                .MaximumLength(100)
                .WithMessage("Author's maximum length is around 100 character.");

            RuleFor(b => b.ISBN)
                .MaximumLength(13)
                .WithMessage("ISBN's maximum length is around 13 character.");
        }
    }
}
