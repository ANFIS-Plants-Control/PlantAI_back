using Application.DTOs.UserDTO;
using Application.Interfaces.Services;
using Application.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : Controller
    {

        private IUserService _service;
        private readonly TokenBuilderService tokenBuilderService;
        public UsersController(IUserService service, TokenBuilderService tokenBuilderService)
        {
            _service = service;
            this.tokenBuilderService = tokenBuilderService;
        }

        [Authorize]
        [HttpGet]
        public async Task<IActionResult> GetUserById(int Id)
        {
            try
            {
                var response = await _service.GetUserByIdAsync(Id);
                return Ok(response);
            }catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreateUserAsync(CreateUserDto dto)
        {
            try
            {
                UserResponseDto response = await _service.CreateUserAsync(dto);
                return CreatedAtAction(nameof(GetUserById), new { Id = response.Id}, response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet("get_token")]
        public async Task<IActionResult> GetTokenAsync(SignInUserDto dto)
        {
            try 
            {
                var existed = await _service.GetUserByLoginAsync(dto.Login);
                if (existed == null) return BadRequest();
                string token = await tokenBuilderService.Create(dto);
                return Ok(token);
            }catch(Exception ex) 
            { 
                return BadRequest(ex.Message); 
            }
        }
    }
}
