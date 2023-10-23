using WebApplication1.Dto;

namespace WebApplication1.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserDto>> GetUsers();
        Task<GetUserDto> GetUserById(int id);
        Task<string> CreateUser(CreateUserDto user);
    }
}
