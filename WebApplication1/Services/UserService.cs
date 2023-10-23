using AutoMapper;
using WebApplication1.Dto;
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
