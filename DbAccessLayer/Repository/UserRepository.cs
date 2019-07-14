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

        public bool RegisterUserAsync(User user)
        {
            if (_context.Users.Any(p => p.Username == user.Username) || _context.Users.Any(p => p.Email == user.Email))
            {
                return false;
            }
            else
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return true;
            }
        }
    }
}
