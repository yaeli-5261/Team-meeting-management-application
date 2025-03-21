using AutoMapper;
using MeetSummarizer.Core.DTOs;
using MeetSummarizer.Core.Entities;
using MeetSummarizer.Core.IRepository;
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
        private readonly IMeetingRepository _meetingRepository;
        private readonly IMapper _mapper;

        public MeetingService(IMeetingRepository meetingRepository, IMapper mapper)
        {
            _meetingRepository = meetingRepository;
            _mapper = mapper;
        }

        public async Task<List<MeetingDTO>> GetAllMeetings()
        {
            var meetings = await _meetingRepository.GetAllMeetingAsync();
            return _mapper.Map<List<MeetingDTO>>(meetings);
        }

        public async Task<MeetingDTO> GetMeetingById(int id)
        {
            var meeting = await _meetingRepository.GetMeetingByIdAsync(id);
            return meeting != null ? _mapper.Map<MeetingDTO>(meeting) : null;
        }

        public async Task AddMeeting(Meeting meeting)
        {
            await _meetingRepository.AddMeetingAsync(meeting);
        }

        public async Task<MeetingDTO> UpdateMeeting(int id, MeetingPostDTO meetingDto)
        {
            var updatedMeeting = await _meetingRepository.UpdateMeetingAsync(id, _mapper.Map<Meeting>(meetingDto));
            return updatedMeeting != null ? _mapper.Map<MeetingDTO>(updatedMeeting) : null;
        }

        public async Task<bool> DeleteMeeting(int id)
        {
            return await _meetingRepository.DeleteMeetingAsync(id);
        }
    }
}
