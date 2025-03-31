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
    public class UserRepository : IUserRepository
    {
        private readonly LibraryDbContext _dbContext;

        public UserRepository(LibraryDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<int> AddAsync(User entity)
        {
            await _dbContext.Users.AddAsync(entity);
            await _dbContext.SaveChangesAsync();

            return entity.Id;
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await _dbContext.Users.AsNoTracking().ToListAsync();
        }

        public async Task<User> GetByIdAsync(int id)
        {
            return await _dbContext.Users.AsNoTracking().SingleOrDefaultAsync(x=>x.Id == id);
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(x => x.Email == email && x.Password == passwordHash);
        }

        public async Task UpdateAsync(User entity)
        {
            _dbContext.Users.Update(entity);
        }
    }
}
