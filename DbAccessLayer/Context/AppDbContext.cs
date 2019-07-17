using DbAccessLayer.Entities;
using DbAccessLayer.Models;
using DbAccessLayer.ModelsDTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DbAccessLayer.Context
{
    public class AppDbContext: DbContext
    {
		public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
		{
		}

		public DbSet<UserEntity> Users { get; set; }
        public DbSet<User_Role> User_Role { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<MessageEntity> Messages { get; set; }

	}
}
