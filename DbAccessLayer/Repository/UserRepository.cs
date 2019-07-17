using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbAccessLayer.Context;
using DbAccessLayer.Models;
using DbAccessLayer.ModelsDTO;
using Microsoft.EntityFrameworkCore;

namespace DbAccessLayer.Repository
{
    public class UserRepository : BaseRepository, IUserRepository
    {
        public UserRepository(AppDbContext context) : base(context)
        {
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

        public IEnumerable<UserEntity> GetUsers()
        {
            var users = _context.Users.OrderBy(a => a.Username).ToList();
            return users;
        }

        public Task<UserDTO> GetUserByID(int userId)
        {
            var task = new Task<UserDTO>(() =>
            {
                var userObject = _context.Users.FirstOrDefault<UserEntity>(user => user.Id == userId);
                var userDTO = new UserDTO(userObject.FullName,userObject.Email,userObject.Username,userObject.Password);
                return userDTO;
            });

            task.Start();

            return task;
        }

        //public Task<UserEntity> GetUserByUsername(string name)
        //{
        //    var task = new Task<UserEntity>(() =>
        //    {
        //        var userDTO = new UserEntity();
        //        var userObject = _context.Users.FirstOrDefault<UserEntity>(user => user.Username.Equals(username));
        //        if (userRoleObject != null)
        //        {
        //            var roleObject = context.Roles.FirstOrDefault<Role>(role => role.Id == userRoleObject.RoleID);
        //            if (roleObject != null)
        //            {
        //                userDTO = new UserDTO(userObject.Id, userObject.Name, userObject.Surname, userObject.DateOfBirth, userObject.Email, userObject.Username, userObject.Password, roleObject.Permission);
        //            }
        //        }
        //        return userDTO;
        //    });

        //    task.Start();

        //    return task;
        //}

        Task<UserEntity> IUserRepository.GetUserByID(int v)
        {
            throw new NotImplementedException();
        }

        public Task<UserEntity> GetUserByUsername(string name)
        {
            throw new NotImplementedException();
        }
    }
}
