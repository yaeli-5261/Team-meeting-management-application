using AutoMapper;
using MeetSummarizer.Core.DTOs;
using MeetSummarizer.Core.Entities;
using MeetSummarizer.Core.IRepository;
using MeetSummarizer.Core.Repository;
using MeetSummarizer.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetSummarizer.Service
{
    public class MeetingService : IMeetingService
    {
        private readonly IManagerRepository _managerRepository;

        public MeetingService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public async Task<List<Meeting>> GetAllMeetings()
        {
            return await _managerRepository.meetingRepository.GetAllMeetingAsync();
        }

        public async Task<Meeting> GetMeetingById(int id)
        {
            return await _managerRepository.meetingRepository.GetMeetingByIdAsync(id);

        }

        public async Task AddMeeting(Meeting meeting)
        {
            await _managerRepository.meetingRepository.AddMeetingAsync(meeting);
            await _managerRepository.SaveAsync();
        }

        public async Task UpdateMeeting(int id, Meeting meeting)
        {
            await _managerRepository.meetingRepository.UpdateMeetingAsync(id, meeting);
            await _managerRepository.SaveAsync();
        }

        public async Task DeleteMeeting(int id)
        {
            await _managerRepository.meetingRepository.DeleteMeetingAsync(id);
            await _managerRepository.SaveAsync();
        }
    }
}
