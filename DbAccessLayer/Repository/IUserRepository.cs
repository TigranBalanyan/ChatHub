using DbAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbAccessLayer.Repositories;

namespace DbAccessLayer.Repositories
{
    public interface IUserRepository
    {
        bool RegisterUserAsync(User user);
        IList<User> GetAllUsersFromDb();
        Task<User> FindAsync(string userName);
        Task<IEnumerable<User>> GetActiveUsers();
    }
}
