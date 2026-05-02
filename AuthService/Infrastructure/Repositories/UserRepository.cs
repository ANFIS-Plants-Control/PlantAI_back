using Application.Interfaces.Repositories;
using AuthService.Core.Models;
using AuthService.Infrastructure.Persistant;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private AuthDbContext context;
        public UserRepository(AuthDbContext context)
        {
            this.context = context;
        }

        public async Task<User> CreateUserAsync(User user)
        {
            await context.Users.AddAsync(user);
            await context.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> GetAllUsersAsync()
        {
            return await context.Users.ToListAsync();
        }

        public async Task<User> GetUserByIdAsync(int Id)
        {
            return await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<User> GetUserByLoginAsync(string Login)
        {
            return await context.Users
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.Login == Login);
        }
    }
}
