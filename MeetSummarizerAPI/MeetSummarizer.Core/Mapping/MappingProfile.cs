using AutoMapper;
using MeetSummarizer.Core.DTOs;
using MeetSummarizer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetSummarizer.Core.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {

            CreateMap<Meeting, MeetingDTO>().ReverseMap();
            CreateMap<Transcript, TranscriptDTO>().ReverseMap();
            CreateMap<Transcript, TranscriptPutDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UserCreateDTO>().ReverseMap();
            CreateMap<UserRole, UserRoleDTO>().ReverseMap();
            CreateMap<Role, RoleDTO>().ReverseMap();
            CreateMap<RegisterDto, User>().ReverseMap();
            CreateMap<UserRoleCreateDTO, UserRole>().ReverseMap();
            CreateMap<UserRolePutDTO, UserRole>().ReverseMap();
          
        }
    }
}
