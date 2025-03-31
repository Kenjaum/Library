using Library.Core.Entities;
using Library.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Persistence.Repositories
{
    public class LoanRepository : ILoanRepository
    {
        private readonly LibraryDbContext _dbContext;

        public LoanRepository(LibraryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<int> AddAsync(Loan entity)
        {
            await _dbContext.Loans.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IEnumerable<Loan>> GetAllAsync()
        {
            return await _dbContext.Loans.AsNoTracking().ToListAsync();
        }

        public async Task<Loan> GetByIdAsync(int id)
        {
            return await _dbContext.Loans.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Loan entity)
        {
            _dbContext.Loans.Update(entity);
        }
    }
}
