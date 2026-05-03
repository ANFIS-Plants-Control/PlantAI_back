namespace Application.DTOs.UserDTO
{
    public record CreateUserDto(string Login, string Password, int RoleId);
}
