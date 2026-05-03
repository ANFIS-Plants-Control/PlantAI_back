using Application.DTOs.UserDTO;
using Application.Interfaces.Repositories;
using Application.Interfaces.Services;
using AuthService.Core.Models;
using Application.Utils.Mapping;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResponseDto> CreateUserAsync(CreateUserDto dto)
        {
            var existedUser = await _repository.GetUserByLoginAsync(dto.Login);
            if (existedUser != null)
            {
                throw new Exception($"User with login {dto.Login} already exists");
            }
            
            PasswordHasher hasher = new PasswordHasher();
            string passwordHash = hasher.GenerateHashPassword(dto.Password);

            User user = User.Create(dto.Login, dto.RoleId, passwordHash);
            var newUser = await _repository.CreateUserAsync(user);
            UserResponseDto response = newUser.EntityToResponseDto();
            return response;
        }

        public async Task<UserResponseDto> GetUserByIdAsync(int Id)
        {
            var user = await _repository.GetUserByIdAsync(Id);
            UserResponseDto response = user.EntityToResponseDto();
            return response;
        }

        public async Task<UserResponseDto> GetUserByLoginAsync(string Login)
        {
            var user = await _repository.GetUserByLoginAsync(Login);
            UserResponseDto response = user.EntityToResponseDto();
            return response;
        }
    }
}
