using MeetSummarizer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetSummarizer.Core.DTOs
{
    public class UserRoleDTO
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }  
    }
    public class UserRolePutDTO
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; }
    }
    public class UserRoleCreateDTO
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }

}
