using Microsoft.AspNetCore.Mvc;
using WebApplication1.Entites;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var users = await _userRepository.GetUsers();

                if (users == null)
                {
                    return NotFound();
                }
                else
                {
                    
                    return Ok(users);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from the database.");
            }
        }

        [HttpGet]
        [Route("GetUserById")]
        public async Task<ActionResult<User>> GetUserById(int id)
        {
            try
            {
                var users = await _userRepository.GetUserById(id);

                if (users == null)
                {
                    return NotFound();
                }
                else
                {

                    return Ok(users);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from the database.");
            }
        }

        [HttpGet]
        [Route("GetUserByEmail")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userRepository.GetUserByEmail(email);

                if (user == null)
                {
                    return NotFound();
                }
                else
                {

                    return Ok(user);
                }
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Error retrieving from the database.");
            }
        }
    }
}
