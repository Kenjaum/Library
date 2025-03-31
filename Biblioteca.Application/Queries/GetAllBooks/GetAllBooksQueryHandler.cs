using AutoMapper;
using Library.Application.Queries.GetAllLoans;
using Library.Application.Queries.GetAllUsers;
using Library.Application.ViewModels;
using Library.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.GetAllBooks
{
    public class GetAllLoansQueryHandler : IRequestHandler<GetAllLoansQuery, IEnumerable<LoanViewModel>>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetAllLoansQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<LoanViewModel>> Handle(GetAllLoansQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAllAsync();

            if (books == null) return Enumerable.Empty<LoanViewModel>();

            var viewModel = _mapper.Map<IEnumerable<LoanViewModel>>(books);

            return viewModel;
        }
    }
}
