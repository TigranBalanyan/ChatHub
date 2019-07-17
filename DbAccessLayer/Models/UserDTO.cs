using System;
using System.Collections.Generic;
using System.Text;

namespace DbAccessLayer.Models
{
    public class UserDTO
    {
        public UserDTO(string fullName, string email, string username, string password)
        {
            FullName = fullName;
            Email = email;
            Username = username;
            Password = password;
        }

        public string FullName { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string IPLocal { get; set; }

    }
}
