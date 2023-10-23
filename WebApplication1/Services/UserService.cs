using AutoMapper;
using Serilog;
using WebApplication1.Dto;
using WebApplication1.Entites;
using WebApplication1.Repositories.Contracts;
using WebApplication1.Services.Contracts;

namespace WebApplication1.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UserService(IUserRepository userRepository,IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public async Task<string> CreateUser(CreateUserDto user)
        {
            string message = String.Empty;
            try
            {
                message = await _userRepository.CreateUser(_mapper.Map<User>(user));
            }
            catch(Exception e)
            {
                Log.Error(e, e.Message);
                if(message == "Eroare la procesare in baza de date")
                {
                    throw new Exception(message);
                }
                else
                {
                    throw new Exception("Eroare in procesul de procesare a datelor.");
                }
            }
            
            return message;
        }

        public async Task<GetUserDto> GetUserById(int id)
        {
            var user = _mapper.Map<GetUserDto>(await _userRepository.GetUserById(id));
            return user;
        }

        public async Task<IEnumerable<GetUserDto>> GetUsers()
        {
            var users = _mapper.Map<IEnumerable<GetUserDto>>(await _userRepository.GetUsers());
            return users;
        }
    }
}
