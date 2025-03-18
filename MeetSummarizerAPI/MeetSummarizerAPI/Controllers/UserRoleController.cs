using AutoMapper;
using MeetSummarizer.Core.DTOs;
using MeetSummarizer.Core.Entities;
using MeetSummarizer.Core.IServices;
using Microsoft.AspNetCore.Mvc;
using static MeetSummarizer.Core.DTOs.UserRoleDTO;

namespace MeetSummarizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRoleController : ControllerBase
    {
        private readonly IUserRoleService _userRoleService;
        private readonly IMapper _mapper;

        public UserRoleController(IUserRoleService userRoleService, IMapper mapper)
        {
            _userRoleService = userRoleService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserRoleDTO>>> GetAll()
        {
            var userRoles = await _userRoleService.GetAllUserRoles();
            return Ok(userRoles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserRoleDTO>> GetById(int id)
        {
            var userRole = await _userRoleService.GetUserRoleById(id);
            if (userRole == null)
                return NotFound(new { message = "UserRole not found" });

            return Ok(userRole);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UserRoleCreateDTO userRoleCreateDto)
        {
            var createdUserRole = _mapper.Map<UserRole>(userRoleCreateDto);
            await _userRoleService.AddUserRole(createdUserRole);
            return CreatedAtAction(nameof(GetById), new { id = createdUserRole.Id }, createdUserRole);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] UserRolePutDTO userRoleDto)
        {
            var current = await _userRoleService.GetUserRoleById(id);

            if (current == null)
            {
                return NotFound(new { message = "UserRole not found." });
            }
            UserRole UserRole = _mapper.Map<UserRole>(userRoleDto);

            await _userRoleService.UpdateUserRole(id, UserRole);
            return Ok(new { message = "UserRole updated successfully." });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedUserRole = await _userRoleService.GetUserRoleById(id);
            if (deletedUserRole == null)
                return NotFound(new { message = "UserRole not found" });

            await _userRoleService.DeleteUserRole(id);
            return Ok(new { message = "UserRole deleted" });
        }
    }

}
