using Microsoft.EntityFrameworkCore;
using WebApplication1.Data;
using WebApplication1.Entites;
using WebApplication1.Repositories.Contracts;

namespace WebApplication1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LinktreeDbContext _dbContext;

        public UserRepository(LinktreeDbContext dbContext)
        { 
            _dbContext = dbContext;
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await this._dbContext.Users.Where(u => u.Email == email).FirstAsync();

            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await this._dbContext.Users.Where(u => u.Id == id).FirstAsync();

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await this._dbContext.Users.ToListAsync();

            return users;
        }
    }
}
