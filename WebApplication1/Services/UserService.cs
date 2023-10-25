using AutoMapper;
using Serilog;
using WebApplication1.Dto;
using WebApplication1.Entites;
using WebApplication1.Repositories.Contracts;
using WebApplication1.Responses;
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

        public async Task<Response> CreateUser(CreateUserDto user)
        {

            try
            {
                var response = await _userRepository.CreateUser(_mapper.Map<User>(user));
                return response;
            }
            catch(Exception e)
            {
                Log.Error(e, e.Message);
                
                throw new Exception("Eroare interna!");
                
            }
        }

        public async Task<Response> DeleteUser(int id)
        {
            try
            {
                var user = await _userRepository.GetUserById(id);
                if (user == null)
                    return new Response(StatusCodes.Status400BadRequest, "Utilizatorul nu exista!");
                return await _userRepository.DeleteUser(user);
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);

                throw new Exception("Eroare interna!");
            }
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

        public async Task<Response> UpdateUser(UpdateUserDto userDto, int id)
        {
            try
            {
                var user = await _userRepository.GetUserById(id);

                if (user == null)
                    return new Response(StatusCodes.Status400BadRequest, "Utilizatorul nu exista!");

                var newUser = _mapper.Map<User>(userDto);
                user.Name = newUser.Name;
                return await _userRepository.UpdateUser(user);
            }
            catch(Exception e) 
            {
                Log.Error(e, e.Message);

                throw new Exception("Eroare interna!");
            }
        }
    }
}
