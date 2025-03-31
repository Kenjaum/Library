using AutoMapper;
using Library.Core.Entities;
using Library.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.CreateBook
{
    public class CreateBookHandler : IRequestHandler<CreateBookCommand, int>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public CreateBookHandler(IBookRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);

            await _repository.AddAsync(book);

            return book.Id;
        }
    }
}
