using AutoMapper;
using MeetSummarizer.Core.DTOs;
using MeetSummarizer.Core.Entities;
using MeetSummarizer.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace MeetSummarizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingController : ControllerBase
    {
        private readonly IMeetingService _meetingService;
        private readonly IMapper _mapper;

        public MeetingController(IMeetingService meetingService, IMapper mapper)
        {
            _meetingService = meetingService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<MeetingDTO>>> GetAll()
        {
            var meetings = await _meetingService.GetAllMeetings();
            return Ok(meetings);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<MeetingDTO>> GetById(int id)
        {
            var meeting = await _meetingService.GetMeetingById(id);
            if (meeting == null)
                return NotFound(new { message = "Meeting not found" });

            return Ok(meeting);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] MeetingPostDTO meetingDto)
        {
            var meeting = _mapper.Map<Meeting>(meetingDto);
            await _meetingService.AddMeeting(meeting);
            return CreatedAtAction(nameof(GetById), new { id = meeting.Id }, _mapper.Map<MeetingDTO>(meeting));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] MeetingPostDTO meetingDto)
        {
            var updatedMeeting = await _meetingService.UpdateMeeting(id, meetingDto);
            if (updatedMeeting == null)
                return NotFound(new { message = "Meeting not found." });

            return Ok(updatedMeeting);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deleted = await _meetingService.DeleteMeeting(id);
            if (!deleted)
                return NotFound(new { message = "Meeting not found." });

            return Ok(new { message = "Meeting deleted" });
        }
    }
}
