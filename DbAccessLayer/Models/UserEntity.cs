using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DbAccessLayer.ModelsDTO
{
    /// <summary>
    /// Model for User Table interaction
    /// </summary>
    public class UserEntity
    {

        public int Id;
        public string fullName;
        public string email;
        public string username;
        public string password;
        public string permission;

        public UserEntity()
        {
        }

        public UserEntity(int id, string fullName, string email, string username, string password, string permission)
        {
            this.Id = id;
            this.fullName = fullName;
            this.email = email;
            this.username = username;
            this.password = password;
            this.permission = permission;
        }

        public string FullName { get; set; }

        [EmailAddress]
		public string Email { get; set; }

		public string Username { get; set; }

		public string Password { get; set; }

		public string IPLocal { get; set; }
	}
}
