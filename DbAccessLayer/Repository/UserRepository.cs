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

        public Task<User> FindAsync(long v)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<User>> GetActiveUsers()
		{
			return await _context.Users.Where(p => p.IPLocal != null).ToListAsync();
		}

        public IList<User> GetAllUsersFromDb()
        {
            return  _context.Users.ToList();
        }

        public void RegisterUserAsync(User user)
        {
             _context.Users.Add(user);
            _context.SaveChanges();
        }
    }
}
