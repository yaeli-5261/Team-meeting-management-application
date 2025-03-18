using MeetSummarizer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetSummarizer.Core.IRepository
{
    public interface IMeetingRepository
    {
        Task<List<Meeting>> GetAllMeetingAsync();
        Task<Meeting> GetMeetingByIdAsync(int id);
        Task AddMeetingAsync(Meeting meeting);
        Task UpdateMeetingAsync(int id, Meeting meeting);
        Task DeleteMeetingAsync(int id);
    }
}

