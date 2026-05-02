namespace Application.DTOs.UserDTO
{
    public record CreateUserDto(string Login, string PasswordHash, int RoleId);
}
