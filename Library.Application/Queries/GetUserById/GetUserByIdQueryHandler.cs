using AutoMapper;
using Library.Application.ViewModels;
using Library.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserViewModel>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetUserByIdQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<UserViewModel> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            var book = await _repository.GetByIdAsync(request.Id);

            if (book == null) return null;

            var viewModel = _mapper.Map<UserViewModel>(book);

            return viewModel;
        }
    }
}
