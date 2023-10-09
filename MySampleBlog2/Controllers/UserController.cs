using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MySampleBlog2.Repository.UserRepository;
using MySampleBlog2.Services.UserService;

namespace MySampleBlog2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userservice;
        public UserController(IUserService userService)
        {
            _userservice = userService;
        }

        [AllowAnonymous]
        [HttpPost("authenticate")]
        public IActionResult Authenticate([FromBody] AuthenticateUserDtos Model)
        {
            try
            {
                var user = _userservice.Authenticate(Model.UserName, Model.Password, Model.Email);
                if (user == null)
                {
                    return BadRequest(new { message = "Username or Password is incorrect" });
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the BlogPost: " + ex.Message);
            }

        }

        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterDto UserDto)
        {
            try
            {
                bool ifUserNameUnique = _userservice.isUniqueUser(UserDto.UserName, UserDto.Email);
                if (!ifUserNameUnique)
                {
                    return BadRequest(new { message = "user name already exist" });
                }
                var user = _userservice.Register(UserDto.UserName, UserDto.FirstName, UserDto.LastName, UserDto.MiddleName, UserDto.Password, UserDto.Email);
                if (user == null)
                {
                    return BadRequest(new { message = "error while registering" });
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while creating the BlogPost: " + ex.Message);
            }




        }
    }
}
