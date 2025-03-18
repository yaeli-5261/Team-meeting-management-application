using MeetSummarizer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetSummarizer.Core.IRepository
{
    public interface IUserRoleRepository
    {
        Task<List<UserRole>> GetAllUserRolesAsync();
        Task<UserRole> GetUserRoleByIdAsync(int id);
        Task AddUserRoleAsync(UserRole userRole);
        Task UpdateUserRoleAsync(int id, UserRole userRole);
        Task DeleteUserRoleAsync(int id);
    }


}
