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
        Task<IEnumerable<UserEntity>> GetAllUsersFromDb();
        Task<UserEntity> GetUserByUsername(string userName);
        Task<IEnumerable<UserEntity>> GetActiveUsers();
        IEnumerable<UserEntity> GetUsers();
        Task<UserEntity> GetUserByID(int userId);
    }
}
