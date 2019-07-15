using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DbAccessLayer.Models;
using DbAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace RegistrationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;

        public UsersController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var response =  await userRepository.RegisterUserAsync(user);
            if (!response)
            {
                return BadRequest("Please enter a different email or username");
            }
            else
            {
                return Ok();
            }
        }

        [HttpGet]
        public async Task<IList<User>> GetAllUsers()
        {
            return userRepository.GetAllUsersFromDb();
        }
    }
}