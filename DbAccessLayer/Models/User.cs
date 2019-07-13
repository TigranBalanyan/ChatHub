using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DbAccessLayer.Models
{
    public class User
    {
		[Required]
		public int Id { get; set; }

		[Required]
		public string FullName { get; set; }

		[Required]
		[EmailAddress]
		public string Email { get; set; }

		[Required]
		public string Username { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		public string IPLocal { get; set; }
	}
}
