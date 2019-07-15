using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbAccessLayer.Context;
using DbAccessLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace DbAccessLayer.Repositories
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
        }

        public Task<User> FindAsync(string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetActiveUsers()
        {
            return await _context.Users.Where(p => p.IPLocal != null).ToListAsync();
        }

        public IList<User> GetAllUsersFromDb()
        {
            return _context.Users.ToList();
        }

        public async Task<bool> RegisterUserAsync(User user)
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
