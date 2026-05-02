using Core.Models;

namespace AuthService.Core.Models;

public class User{
    public int Id {get; init; }
    public string Login {get; init; }
    public string PasswordHash { get; set; }
    public int RoleId { get; set; }
    public UserRole UserRole { get; set; }

    public static User Create(string Login, int RoleId, string PasswordHash)
    {
        if (string.IsNullOrWhiteSpace(Login)) throw new Exception("Login must be not empty");
        if (string.IsNullOrWhiteSpace(PasswordHash)) throw new Exception("Password must be not empty");

        User user = new User()
        {
            Login = Login,
            RoleId = RoleId,
            PasswordHash = PasswordHash
        };
        return user;
    }
}