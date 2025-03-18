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

    public class MeetingController: ControllerBase
    {
        private readonly IMeetingService _meetingService;
        private readonly IMapper _mapper;

        public MeetingController(IMeetingService meetingService, IMapper mapper)
        {
            _meetingService = meetingService;
            _mapper = mapper;
        }
        [HttpGet("Admin")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult<List<MeetingDTO>>> GetAll()
        {
            var meeting = await _meetingService.GetAllMeetings();
            return Ok(meeting);
        }

      
        [HttpGet("{id}")]

        public async Task<ActionResult<MeetingDTO>> GetById(int id)
        {
            var meeting = await _meetingService.GetMeetingById(id);
            if (meeting == null)
                return NotFound(new {message = "Meeting noy found"});

            return Ok(meeting);
        }

        //add meeting only for admin

        [HttpPost("Admin")]
        [Authorize(Policy = "Admin")]
        public async Task<ActionResult> Post([FromBody] MeetingDTO meetingDto)
        {
            var createdMeeting = _mapper.Map<Meeting>(meetingDto);
            await _meetingService.AddMeeting(createdMeeting);
            return CreatedAtAction(nameof(GetById), new { id = createdMeeting.Id }, createdMeeting);
        }
        //update meeting
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] MeetingDTO meetingDto)
        {
            var updated = await _meetingService.GetMeetingById(id);
            if (updated==null)
                return NotFound(new { message = "Meeting not found." });
            Meeting meeting = _mapper.Map<Meeting>(meetingDto);
            await _meetingService.UpdateMeeting(id, meeting);
            return Ok(new { message = "Meeting updated" });
        }
       

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedMeeting = await _meetingService.GetMeetingById(id);
            if (deletedMeeting==null)
                return NotFound(new { message = "Meeting not found." });

            await _meetingService.DeleteMeeting(id);
            return Ok(new { message = "Meeting deleted" });
        }
    }
}
