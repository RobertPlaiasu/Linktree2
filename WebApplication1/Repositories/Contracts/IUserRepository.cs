using WebApplication1.Entites;

namespace WebApplication1.Repositories.Contracts
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User> GetUserById(int id);
        Task<User> GetUserByEmail(string email);
        Task<string> CreateUser(User user);
    }
}
