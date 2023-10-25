using WebApplication1.Entites;
using WebApplication1.Responses;

namespace WebApplication1.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<Response> CreateUser(User user);
        Task<Response> DeleteUser(User user);
        Task<Response> UpdateUser(User user);
    }
}
