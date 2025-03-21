﻿using MeetSummarizer.Core.Entities;
using MeetSummarizer.Core.IRepository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetSummarizer.Data.Repositories
{
    public class MeetingRepository : IMeetingRepository
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
            return await _context.Meetings.FindAsync(id);
        }

        public async Task AddMeetingAsync(Meeting meeting)
        {
            await _context.Meetings.AddAsync(meeting);
            await _context.SaveChangesAsync();
        }

        public async Task<Meeting> UpdateMeetingAsync(int id, Meeting meeting)
        {
            var meetingToUpdate = await GetMeetingByIdAsync(id);
            if (meetingToUpdate == null)
                return null;

            meetingToUpdate.Name = meeting.Name;
            meetingToUpdate.Date = meeting.Date;
            meetingToUpdate.TeamId = meeting.TeamId;
            meetingToUpdate.LinkTranscriptFile = meeting.LinkTranscriptFile;
            meetingToUpdate.LinkOrinignFile= meeting.LinkOrinignFile;

            await _context.SaveChangesAsync();
            return meetingToUpdate;
        }

        public async Task<bool> DeleteMeetingAsync(int id)
        {
            var meeting = await GetMeetingByIdAsync(id);
            if (meeting == null)
                return false;

            _context.Meetings.Remove(meeting);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
