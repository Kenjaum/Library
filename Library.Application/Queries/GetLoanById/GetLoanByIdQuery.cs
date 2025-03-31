using Library.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.GetLoanById
{
    public class GetLoanByIdQuery : IRequest<LoanViewModel>
    {
        public GetLoanByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
