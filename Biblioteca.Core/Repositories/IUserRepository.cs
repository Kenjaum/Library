using Library.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Core.Repositories
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAllAsync();
        Task<User> GetByIdAsync(int id);
        Task<int> AddAsync(User entity);
        Task UpdateAsync(User entity);
        Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
