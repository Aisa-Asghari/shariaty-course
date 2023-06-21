using Microsoft.AspNetCore.Mvc;
using shariaty_course.Models;

namespace shariaty_course.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        // POST: api/Users
        [HttpPost]
        public IActionResult CreateUser([FromBody] User user)
        {
            var createdUser = _userService.AddUser(user);

            return CreatedAtAction(nameof(GetUserById), new { id = createdUser.Id }, createdUser);
        }

        //GET: api/Users/1
        [HttpGet("{id}")]
        public IActionResult GetUserById(int id)
        {
            var user = _userService.GetUser(id);

            if (user == null)
            {
                return NotFound();
            }

            return Ok(user);
        }
    }
}