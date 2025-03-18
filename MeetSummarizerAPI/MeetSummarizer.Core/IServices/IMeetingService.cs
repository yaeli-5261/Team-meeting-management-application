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
        Task<List<Meeting>> GetAllMeetings();
        Task<Meeting> GetMeetingById(int id);

        Task AddMeeting(Meeting meeting);

        Task UpdateMeeting(int id, Meeting meeting);

        Task DeleteMeeting(int id);
    }
}
