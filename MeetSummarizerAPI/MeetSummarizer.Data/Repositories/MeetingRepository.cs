using MeetSummarizer.Core.Entities;
using MeetSummarizer.Core.IRepository;
using MeetSummarizer.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetSummarizer.Data.Repositories
{
    public class MeetingRepository: IMeetingRepository
    {
        private readonly DataContext _context;

        public MeetingRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Meeting>> GetAllMeetingAsync()
        {
            return await _context.Meetings.ToListAsync();
        }
      
        public async Task<Meeting> GetMeetingByIdAsync(int id)
        {
            var meeting= await _context.Meetings
                .FirstOrDefaultAsync(m => m.Id == id);

            if (meeting == null)
            {
                return null;
            }
            return meeting; 
        }

        public async Task AddMeetingAsync(Meeting meeting)
        {
            await _context.Meetings.AddAsync(meeting);

        }

        public async Task UpdateMeetingAsync(int id,Meeting meeting)
        {
            var meetingToUpdate = await GetMeetingByIdAsync(id);
            if (meetingToUpdate == null)
            {
                throw new KeyNotFoundException($"Meeting with id {id} not found");
            }
            //אחכ אפשר לשנות לפי סינון---
            meetingToUpdate.Name = meeting.Name;    
            meetingToUpdate.Date = meeting.Date;    
           
                
        }

        public async Task DeleteMeetingAsync(int id)
        {
            var meeting =await GetMeetingByIdAsync(id);
            if (meeting != null)
                _context.Meetings.Remove(meeting);
        }


    }
}
