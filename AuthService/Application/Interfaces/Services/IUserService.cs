using Application.DTOs.UserDTO;
using AuthService.Core.Models;

namespace Application.Interfaces.Services
{
    public interface IUserService
    {

        public Task<UserResponseDto> CreateUserAsync(CreateUserDto dto);
        public Task<UserResponseDto> GetUserByLoginAsync(string Login);

    }
}
