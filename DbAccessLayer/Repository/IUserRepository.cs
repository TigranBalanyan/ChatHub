using DbAccessLayer.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbAccessLayer.Repository
{
    public interface IUserRepository
    {
        Task<bool> RegisterUserAsync(UserEntity user);
        IList<UserEntity> GetAllUsersFromDb();
        Task<UserEntity> FindAsync(string userName);
        Task<IEnumerable<UserEntity>> GetActiveUsers();
    }
}
