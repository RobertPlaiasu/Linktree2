using Microsoft.EntityFrameworkCore;
using Serilog;
using WebApplication1.Data;
using WebApplication1.Entites;
using WebApplication1.Repositories.Contracts;
using WebApplication1.Responses;

namespace WebApplication1.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly LinktreeDbContext _dbContext;

        public UserRepository(LinktreeDbContext dbContext)
        { 
            _dbContext = dbContext;
        }

        public async Task<Response> CreateUser(User user)
        {
            try
            {
                await _dbContext.Users.AddAsync(user);
                await _dbContext.SaveChangesAsync();
                return new Response(StatusCodes.Status201Created, "Utilizatorul a fost creat cu scucces cu succes!");
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                throw new Exception("Eroare la procesare in baza de date");
            }
        }

        public async Task<Response> DeleteUser(User user)
        {
            try
            {
                _dbContext.Users.Remove(user);
                await _dbContext.SaveChangesAsync();
                return new Response(StatusCodes.Status200OK, "Utilizatorul a sters cu succes!");
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                throw new Exception("Eroare la procesare in baza de date");
            }
        }

        public async Task<User> GetUserByEmail(string email)
        {
            var user = await this._dbContext.Users.Where(u => u.Email == email).FirstAsync();

            return user;
        }

        public async Task<User> GetUserById(int id)
        {
            var user = await this._dbContext.Users.FindAsync(id);

            return user;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var users = await this._dbContext.Users.ToListAsync();

            return users;
        }

        public async Task<Response> UpdateUser(User user)
        {
            try
            {
                _dbContext.Update(user);
                await _dbContext.SaveChangesAsync();
                return new Response(StatusCodes.Status200OK, "Schimbarile au fost realizate!");
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                throw new Exception("Eroare la procesare in baza de date");
            }
        }
    }
}
