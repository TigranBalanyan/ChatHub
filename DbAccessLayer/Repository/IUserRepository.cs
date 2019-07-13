using DbAccessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbAccessLayer.Repositories
{
    public interface IUserRepository
    {
		Task<IEnumerable<User>> GetActiveUsers();
        void RegisterUserAsync(User user);
        IList<User> GetAllUsersFromDb();
        Task<User> FindAsync(string userName);
        Task<User> FindAsync(long v);
    }
}
