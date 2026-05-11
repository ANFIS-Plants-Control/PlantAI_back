using Application.DTOs.UserDTO;
using Application.Interfaces.Repositories;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Application.Services
{
    public class TokenBuilderService
    {
        private IUserRepository _repository;
        private ProjectOptions projectOptions;
        
        public TokenBuilderService(IUserRepository repository, ProjectOptions projectOptions)
        {
            _repository = repository;
            this.projectOptions = projectOptions;
        }

        public async Task<string> Create(SignInUserDto dto)
        {
            var user = await _repository.GetUserByLoginAsync(dto.Login);
            if (user == null) throw new Exception("User does not exists");
            var claims = new List<Claim> {
                new Claim("id", user.Id.ToString()),
                new Claim("login", user.Login),
                new Claim("role", user.RoleId.ToString())
            };
#if debug
            secretKey = AppsettingsReader.GetString("SecretKey");
#endif
            var jwt = new JwtSecurityToken(
               issuer: "PlantAI_auth",
               claims: claims,
               expires: DateTime.UtcNow.AddMinutes(10),
               signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(projectOptions.SecretKey)), SecurityAlgorithms.HmacSha256));
            var handler = new JwtSecurityTokenHandler();

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }
    }
}
