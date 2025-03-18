
using MeetSummarizer.Core.Entities;
using MeetSummarizer.Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetSummarizer.Data.Repositories
{
    public class UserRoleRepository : IUserRoleRepository
    {
        private readonly DataContext _context;

        public UserRoleRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<UserRole>> GetAllUserRolesAsync()
        {
            return await _context.UserRoles.Include(ur => ur.User).Include(ur => ur.Role).ToListAsync();
        }

        public async Task<UserRole> GetUserRoleByIdAsync(int id)
        {
            var userRole = await _context.UserRoles
                .Include(ur => ur.User)
                .Include(ur => ur.Role)
                .FirstOrDefaultAsync(ur => ur.Id == id);

            if (userRole == null)
            {
                return null;
            }
            return userRole;
        }

        public async Task AddUserRoleAsync(UserRole userRole)
        {
            await _context.UserRoles.AddAsync(userRole);
        }

        public async Task UpdateUserRoleAsync(int id, UserRole userRole)
        {
            var userRoleToUpdate = await GetUserRoleByIdAsync(id);
            if (userRoleToUpdate == null)
            {
                throw new KeyNotFoundException($"UserRole with id {id} not found");
            }

            userRoleToUpdate.UserId = userRole.UserId;
            userRoleToUpdate.RoleId = userRole.RoleId;
        }

        public async Task DeleteUserRoleAsync(int id)
        {
            var userRole = await GetUserRoleByIdAsync(id);
            if (userRole != null)
                _context.UserRoles.Remove(userRole);
        }

    }


}
