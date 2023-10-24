using WebApplication1.Dto;
using WebApplication1.Responses;

namespace WebApplication1.Services.Contracts
{
    public interface IUserService
    {
        Task<IEnumerable<GetUserDto>> GetUsers();
        Task<GetUserDto> GetUserById(int id);
        Task<Response> CreateUser(CreateUserDto user);
        Task<Response> DeleteUser(int id);
    }
}
