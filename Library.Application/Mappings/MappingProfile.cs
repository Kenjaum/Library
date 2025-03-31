using AutoMapper;
using Library.Application.Commands.CreateBook;
using Library.Application.Commands.CreateLoan;
using Library.Application.Commands.CreateUser;
using Library.Application.Commands.UpdateBook;
using Library.Application.ViewModels;
using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateUserCommand, User>();
            CreateMap<UserViewModel, User>();
            CreateMap<UpdateBookCommand, Book>();
            CreateMap<UserDetailsViewModel, User>();

            CreateMap<CreateLoanCommand, Loan>();
            CreateMap<LoanDetailsViewModel, Loan>();
            CreateMap<LoanViewModel, Loan>();

            CreateMap<CreateBookCommand, Book>();
            CreateMap<UpdateBookCommand, Book>();
            CreateMap<BookViewModel, Book>();
            CreateMap<BookDetailsViewModel, Book>();
        }
    }
}

