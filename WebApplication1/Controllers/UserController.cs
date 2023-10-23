using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using WebApplication1.Dto;
using WebApplication1.Repositories.Contracts;
using WebApplication1.Services.Contracts;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [DisableCors]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<GetUserDto>>> GetUsers()
        {
            try
            {
                var users = await _userService.GetUsers();

                if (users == null)
                {
                    return NotFound();
                }
                else
                {
                    
                    return Ok(users);
                }
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from the database.");
            }
        }

        [DisableCors]
        [HttpGet]
        [Route("GetUserById")]
        public async Task<ActionResult<GetUserDto>> GetUserById(int id)
        {
            try
            {
                var users = await _userService.GetUserById(id);

                if (users == null)
                {
                    return NotFound();
                }
                else
                {

                    return Ok(users);
                }
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from the database.");
            }
        }

        [DisableCors]
        [HttpPost]
        [Route("register")]
        public async Task<ActionResult> Register()
        {
            return Ok();
        }

        
    }
}
