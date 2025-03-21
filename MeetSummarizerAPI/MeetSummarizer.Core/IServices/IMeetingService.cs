using MeetSummarizer.Core.DTOs;
using MeetSummarizer.Core.Entities;
using MeetSummarizer.Core.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetSummarizer.Core.Services
{
    public interface IMeetingService
    {
        Task<List<MeetingDTO>> GetAllMeetings();
        Task<MeetingDTO> GetMeetingById(int id);
        Task AddMeeting(Meeting meeting);
        Task<MeetingDTO> UpdateMeeting(int id, MeetingPostDTO meetingDto);
        Task<bool> DeleteMeeting(int id);
    }
}
