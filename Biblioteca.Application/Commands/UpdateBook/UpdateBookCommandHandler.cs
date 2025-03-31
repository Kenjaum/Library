using AutoMapper;
using Library.Core.Entities;
using Library.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.UpdateBook
{
    public class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public UpdateBookCommandHandler(IBookRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<Unit> Handle(UpdateBookCommand request, CancellationToken cancellationToken)
        {
            var book = _mapper.Map<Book>(request);

            await _repository.UpdateAsync(book);

            return Unit.Value;
        }
    }
}
