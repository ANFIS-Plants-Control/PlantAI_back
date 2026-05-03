using Application.DTOs.UserDTO;

namespace Application.Interfaces.Services
{
    public interface IUserService
    {

        public Task<UserResponseDto> CreateUserAsync(CreateUserDto dto);
        public Task<UserResponseDto> GetUserByLoginAsync(string Login);
        public Task<UserResponseDto> GetUserByIdAsync(int Id);

    }
}
