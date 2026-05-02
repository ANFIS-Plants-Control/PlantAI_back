using AuthService.Core.Models;

namespace Application.Interfaces.Repositories
{
    public interface IUserRepository
    {

        public Task<User> CreateUserAsync(User user);
        public Task<User> GetUserByLoginAsync(string Login);
        public Task<User> GetUserByIdAsync(int Id);
        public Task<List<User>> GetAllUsersAsync();

    }
}
