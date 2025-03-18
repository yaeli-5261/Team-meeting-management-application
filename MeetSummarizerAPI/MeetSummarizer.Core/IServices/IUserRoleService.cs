using MeetSummarizer.Core.Entities;
using MeetSummarizer.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MeetSummarizer.Core.DTOs.UserRoleDTO;

namespace MeetSummarizer.Core.IServices
{
    public interface IUserRoleService
    {
        Task<List<UserRole>> GetAllUserRoles();
        Task<UserRole> GetUserRoleById(int id);
        Task AddUserRole(UserRole userRole);
        Task UpdateUserRole(int id, UserRole userRole);
        Task DeleteUserRole(int id);
    }


}
