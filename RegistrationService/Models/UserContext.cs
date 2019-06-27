using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegistrationService.Models
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) 
            : base(options)
        {
        }

        public DbSet<BasicUser> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<BasicUser>().ToTable("Users");
            builder.Entity<BasicUser>().HasKey(p => p.Id);
            builder.Entity<BasicUser>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
            builder.Entity<BasicUser>().Property(p => p.FullName).IsRequired().HasMaxLength(50);
            builder.Entity<BasicUser>().Property(p => p.Password).IsRequired();
            builder.Entity<BasicUser>().Property(p => p.Email).IsRequired().HasMaxLength(320);
            builder.Entity<BasicUser>().HasMany(p => p.Roles);

            //builder.Entity<Category>().HasData
            //(
            //    new Category { Id = 100, Name = "Fruits and Vegetables" }, // Id set manually due to in-memory provider
            //    new Category { Id = 101, Name = "Dairy" }
            //);

            builder.Entity<Role>().ToTable("Roles");
            builder.Entity<Role>().HasKey(p => p.Id);
            builder.Entity<Role>().Property(p => p.Id).IsRequired();
            builder.Entity<Role>().Property(p => p.RoleName).IsRequired().HasMaxLength(50);

            builder.Entity<Role>().HasData
            (
                new Role { Id = 100, RoleName = "BasicUser"},
                new Role { Id = 101, RoleName = "SuperUser" }
            );
        }
    }
}
