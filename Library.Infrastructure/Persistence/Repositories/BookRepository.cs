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
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _dbContext;

        public BookRepository(LibraryDbContext dbContext) {
            this._dbContext = dbContext;
        }

        public async Task<int> AddAsync(Book entity)
        {
            await _dbContext.Books.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _dbContext.Books.AsNoTracking().ToListAsync();
        }

        public async Task<Book> GetByIdAsync(int id)
        {
            return await _dbContext.Books.AsNoTracking().SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task UpdateAsync(Book entity)
        {
            _dbContext.Books.Update(entity);
        }
    }
}
