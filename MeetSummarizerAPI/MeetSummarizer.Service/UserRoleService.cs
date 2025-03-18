using AutoMapper;
using MeetSummarizer.Core.DTOs;
using MeetSummarizer.Core.Entities;
using MeetSummarizer.Core.IRepository;
using MeetSummarizer.Core.IServices;
using MeetSummarizer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetSummarizer.Service
{
    public class UserRoleService : IUserRoleService
    {
        private readonly IManagerRepository _managerRepository;

        public UserRoleService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public async Task<List<UserRole>> GetAllUserRoles()
        {
            return await _managerRepository.userRoleRepository.GetAllUserRolesAsync();
        }

        public async Task<UserRole> GetUserRoleById(int id)
        {
            return await _managerRepository.userRoleRepository.GetUserRoleByIdAsync(id);
        }

        public async Task AddUserRole(UserRole userRole)
        {
            await _managerRepository.userRoleRepository.AddUserRoleAsync(userRole);
            await _managerRepository.SaveAsync();
        }

        public async Task UpdateUserRole(int id, UserRole userRole)
        {
            await _managerRepository.userRoleRepository.UpdateUserRoleAsync(id, userRole);
            await _managerRepository.SaveAsync();
        }

        public async Task DeleteUserRole(int id)
        {
            await _managerRepository.userRoleRepository.DeleteUserRoleAsync(id);
            await _managerRepository.SaveAsync();
        }
    }
}
