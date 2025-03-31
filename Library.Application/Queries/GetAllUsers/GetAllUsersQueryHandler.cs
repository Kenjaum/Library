using AutoMapper;
using Library.Application.ViewModels;
using Library.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Queries.GetAllUsers
{
    public class GetAllUsersQueryHandler : IRequestHandler<GetAllUsersQuery, IEnumerable<UserViewModel>>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public GetAllUsersQueryHandler(IBookRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<UserViewModel>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
        {
            var books = await _repository.GetAllAsync();

            if (books == null) return Enumerable.Empty<UserViewModel>();

            var viewModel = _mapper.Map<IEnumerable<UserViewModel>>(books);

            return viewModel;
        }
    }
}
