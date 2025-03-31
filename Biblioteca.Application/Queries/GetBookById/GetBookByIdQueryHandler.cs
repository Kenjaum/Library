using AutoMapper;
using Library.Application.Queries.GetLoanById;
using Library.Application.ViewModels;
using Library.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.GetBookById
{
    public class GetLoanByIdQueryHandler : IRequestHandler<GetLoanByIdQuery, LoanViewModel>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetLoanByIdQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<LoanViewModel> Handle(GetLoanByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetByIdAsync(request.Id);

            if (book == null) return null;

            var viewModel = _mapper.Map<LoanViewModel>(book);

            return viewModel;
        }
    }
}
