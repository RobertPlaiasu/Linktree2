using Microsoft.EntityFrameworkCore;
using Serilog;
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

        public async Task<string> CreateUser(User user)
        {
            try
            {
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                throw new Exception("Eroare la procesare in baza de date");
            }
            return "User-ul a fost inregistrat cu succes";
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
