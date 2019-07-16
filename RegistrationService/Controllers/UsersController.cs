using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AccountControlService.Resources;
using AutoMapper;
using DbAccessLayer.ModelsDTO;
using DbAccessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace RegistrationService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper; 
        public UsersController(IUserRepository userRepository, IMapper mapper)
        {
            this.mapper = mapper;
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
            var newUser = mapper.Map<User, UserDTO>(user);
                
            var response =  await userRepository.RegisterUserAsync(newUser);
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
        public async Task<IList<UserDTO>> GetAllUsers()
        {
            return userRepository.GetAllUsersFromDb();
        }
    }
}