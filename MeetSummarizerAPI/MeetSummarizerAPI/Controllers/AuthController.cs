
using AutoMapper;
using MeetSummarizer.Core.DTOs;
using MeetSummarizer.Core.Entities;
using MeetSummarizer.Core.Interfaces;
using MeetSummarizer.Core.IServices;
using MeetSummarizer.Service;
using Microsoft.AspNetCore.Mvc;

namespace MeetSummarizerAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly AuthService _authService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public AuthController(IConfiguration configuration, AuthService authService, IUserService userService, IMapper mapper)
        {
            _configuration = configuration;
            _authService = authService;
            _userService = userService;
            _mapper = mapper;
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var userRole = await _userService.GetUserByNameAndPasswordAsync(model.Password,model.UserName);

            // כאן יש לבדוק את שם המשתמש והסיסמה מול מסד הנתונים
            if (userRole.Role == "Admin")
            {
                var token = _authService.GenerateJwtToken(model.UserName, new[] { "Admin" });
                return Ok(new { Token = token , User = userRole.UserName });
            }
            else if (userRole.Role == "Worker")
            {
                var token = _authService.GenerateJwtToken(model.UserName, new[] { "Worker" });
                return Ok(new { Token = token, User = userRole.UserName });
            }

            return Unauthorized();
        }
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterDto model)
        {
            if (model == null)
            {
                return Conflict("User is not valid");
            }
            var modelD = _mapper.Map<User>(model);

            var existingUser = await _userService.AddUser(modelD);
            if (existingUser == null)
                return BadRequest();

            var token = _authService.GenerateJwtToken(model.UserName, new[] { model.Role });
            return Ok(new { Token = token });


        }
    }

}


   

