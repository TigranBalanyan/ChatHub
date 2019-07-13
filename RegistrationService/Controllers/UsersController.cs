using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbAccessLayer.Models;
using DbAccessLayer.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace RegistrationService.Controllers
{
   // [Authorize]dsds
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserRepository _userRepository;

        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        // POST: api/Users
        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] User user)
        {
           //return  new JsonResult(from c in User.Claims select new { c.Type, c.Value });
           // if(canAccess.Value )
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _userRepository.RegisterUserAsync(user);

            return Ok();
        }

        [HttpGet]
        public async Task<IList<User>> GetAllUsers()
        {
            return _userRepository.GetAllUsersFromDb();
        }
    }
}