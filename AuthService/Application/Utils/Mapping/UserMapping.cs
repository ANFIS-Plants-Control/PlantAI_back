using Application.DTOs.UserDTO;
using AuthService.Core.Models;

namespace Application.Utils.Mapping
{
    public static class UserMapping
    {
        public static CreateUserDto EntityToCreateDto(this User user) => 
            new CreateUserDto(user.Login, user.PasswordHash, user.RoleId);

        public static UserResponseDto EntityToResponseDto(this User user) => 
            new UserResponseDto(user.Id, user.Login, user.RoleId);
    }
}
