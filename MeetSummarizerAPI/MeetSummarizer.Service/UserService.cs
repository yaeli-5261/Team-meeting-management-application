using System.Collections.Generic;
using System.Threading.Tasks;
using MeetSummarizer.Core.DTOs;
using MeetSummarizer.Core.Entities;
using MeetSummarizer.Core.Interfaces;
using System;
using MeetSummarizer.Data;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using MeetSummarizer.Core.IRepository;
using MeetSummarizer.Data.Repositories;


public class UserService :IUserService
{
    private readonly IManagerRepository _managerRepository;

    public UserService(IManagerRepository managerRepository)
    {
        _managerRepository = managerRepository;
    }

    public async Task<List<User>> GetAllUsers()
    {
        return await _managerRepository.userRepository.GetAllUsersAsync();
    }

    public async Task<User> GetUserById(int id)
    {
        return await _managerRepository.userRepository.GetUserByIdAsync(id);
    }

    public async Task<User> GetUserByNameAndPasswordAsync(string password,string name)
    {
        return await _managerRepository.userRepository.GetUserByNameAndPasswordAsync(password,name);
    }



    //public async Task<User> AddUser(User user)
    //{
    //    // שליפת ה- Role מהדאטהבייס לפי RoleId
    //    var roleEntity = await _managerRepository.roleRepository.GetRoleByIdAsync(user.RoleId);
    //    if (roleEntity == null)
    //        throw new Exception("Role not found");

    //    user.Role = roleEntity;

    //    // ✅ הוספת המשתמש למסד הנתונים
    //    var newUser = await _managerRepository.userRepository.AddUserAsync(user);

    //    // ✅ שמירת השינויים ב-DB
    //    await _managerRepository.SaveAsync();

    //    return newUser;

    //}
    //public async Task<User> AddUser(User user)
    //{
    //    // ✅ שליפת ה- Role מהדאטהבייס לפי RoleId
    //    user.Role = await _managerRepository.roleRepository.GetRoleByIdAsync(user.RoleId)
    //        ?? throw new Exception("Role not found");

    //    var newUser = await _managerRepository.userRepository.AddUserAsync(user);
    //    await _managerRepository.SaveAsync();

    //    return newUser;
    //}


    //public async Task<User> AddUser(User user)
    //{
    //    // ✅ שליפת ה- Role מהדאטהבייס לפי RoleId
    //    user.Role = await _managerRepository.roleRepository.GetRoleByIdAsync(user.RoleId)
    //        ?? throw new Exception("Role not found");

    //    // ✅ הוספת המשתמש למסד הנתונים
    //    var newUser = await _managerRepository.userRepository.AddUserAsync(user);

    //    // ✅ עדכון אוטומטי של Role בהתאם ל-RoleId
    //    newUser.Role = user.Role;
    //    // ✅ שמירת השינויים

    //    await _managerRepository.SaveAsync();

    //    return newUser;
    //}

    public async Task<User> AddUser(User user)
    {
        Console.WriteLine($"RoleId before fetching: {user.RoleId}");

        // 🔹 שליפת ה-Role מהדאטהבייס
        var role = await _managerRepository.roleRepository.GetRoleByIdAsync(user.RoleId)
            ?? throw new Exception("Role not found");

        Console.WriteLine($"Role after fetching: {role.RoleName}");

        // 🔹 קישור ה-Role ליוזר
        user.Role = role;

        // 🔹 חיבור ה-Role ל-DbContext כדי לוודא שהשינוי נשמר
        _managerRepository.userRepository.AttachEntity(role);  // ✅ עכשיו זה עובד

        // 🔹 הוספת המשתמש למסד הנתונים
        await _managerRepository.userRepository.AddUserAsync(user);

        // 🔹 שמירת השינויים
        await _managerRepository.SaveAsync();

        // 🔹 שליפה מחדש כדי לוודא שה-Role נטען עם המשתמש
        var savedUser = await _managerRepository.userRepository.GetUserByIdAsync(user.Id);

        Console.WriteLine($"Saved User Role: {savedUser?.Role?.RoleName}");

        return savedUser;
    }





    public async Task UpdateUser(int id, User user)
    {
        await _managerRepository.userRepository.UpdateUserAsync(id, user);
        await _managerRepository.SaveAsync();
    }

    public async Task DeleteUser(int id)
    {
        await _managerRepository.userRepository.DeleteUserAsync(id);
        await _managerRepository.SaveAsync();
    }

   
}
