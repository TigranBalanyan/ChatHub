using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbAccessLayer.Context;
using DbAccessLayer.ModelsDTO;
using Microsoft.EntityFrameworkCore;

namespace DbAccessLayer.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public Task<UserEntity> FindAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<UserEntity>> GetActiveUsers()
        {
            return await _context.Users.Where(p => p.IPLocal != null).ToListAsync();
        }

        public async Task<IEnumerable<UserEntity>> GetAllUsersFromDb()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<bool> RegisterUserAsync(UserEntity user)
        {
            if (await _context.Users.AnyAsync(p => p.Username == user.Username) ||  await _context.Users.AnyAsync(p => p.Email == user.Email))
            {
                return false;
            }
            else
            {
               await  _context.Users.AddAsync(user);
               await _context.SaveChangesAsync();
               return true;
            }
        }
    }
}
