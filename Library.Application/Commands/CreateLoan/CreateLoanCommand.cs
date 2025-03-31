using Library.Core.Entities;
using MediatR;

namespace Library.Application.Commands.CreateLoan
{
    public class CreateLoanCommand : IRequest<int>
    {
        public int IdUser { get; set; }
        public int IdBook { get; set; }
        public DateTime LoanDate { get; private set; }
    }
}