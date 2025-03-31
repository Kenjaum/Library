using AutoMapper;
using Library.Core.Entities;
using Library.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Commands.CreateLoan
{
    public class CreateLoanHandler : IRequestHandler<CreateLoanCommand, int>
    {
        private readonly ILoanRepository _repository;
        private readonly IMapper _mapper;

        public CreateLoanHandler(ILoanRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }
        public async Task<int> Handle(CreateLoanCommand request, CancellationToken cancellationToken)
        {
            var entity = _mapper.Map<Loan>(request);

            return await _repository.AddAsync(entity);
        }
    }
}
