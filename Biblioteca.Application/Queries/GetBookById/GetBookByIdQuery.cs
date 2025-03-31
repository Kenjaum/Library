using Library.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.GetBookById
{
    public class GetBookByIdQuery : IRequest<BookViewModel>
    {
        public GetBookByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; set; }
    }
}
