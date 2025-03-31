using AutoMapper;
using Library.Core.Entities;
using Library.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, Unit>
    {
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UpdateUserCommandHandler(IUserRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<User>(request);

            await _repository.UpdateAsync(entity);

            return Unit.Value;
        }
    }
}
