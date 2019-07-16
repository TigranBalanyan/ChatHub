using DbAccessLayer.ModelsDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbAccessLayer.Repository
{
    public interface IUserRepository
    {
        Task<bool> RegisterUserAsync(UserDTO user);
        IList<UserDTO> GetAllUsersFromDb();
        Task<UserDTO> FindAsync(string userName);
        Task<IEnumerable<UserDTO>> GetActiveUsers();
    }
}
