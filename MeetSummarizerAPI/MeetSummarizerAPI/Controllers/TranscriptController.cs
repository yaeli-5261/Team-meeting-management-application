using AutoMapper;
using MeetSummarizer.Core.DTOs;
using MeetSummarizer.Core.Entities;
using MeetSummarizer.Core.Services;
using MeetSummarizer.Service;
using Microsoft.AspNetCore.Mvc;

namespace MeetSummarizer.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TranscriptController : ControllerBase
    {
        private readonly ITranscriptService _transcriptService;
        private readonly IMapper _mapper;

        public TranscriptController(ITranscriptService transcriptService, IMapper mapper)
        {
            _transcriptService = transcriptService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<List<TranscriptDTO>>> GetAll()
        {
            var transcripts = await _transcriptService.GetAllTranscripts();
            return Ok(transcripts);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TranscriptDTO>> GetById(int id)
        {
            var transcript = await _transcriptService.GetTranscriptById(id);
            if (transcript == null)
                return NotFound(new { message = "Transcript not found" });

            return Ok(transcript);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] TranscriptDTO transcriptDto)
        {
            var createdTranscript = _mapper.Map<Transcript>(transcriptDto);
            await _transcriptService.AddTranscript(createdTranscript);
            return CreatedAtAction(nameof(GetById), new { id = createdTranscript.Id }, createdTranscript);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] TranscriptDTO transcriptDto)
        {

            var current = await _transcriptService.GetTranscriptById(id);
            if (current == null)
                return NotFound(new { message = "Transcript not found." });

            Transcript transcript = _mapper.Map<Transcript>(transcriptDto);
            await _transcriptService.UpdateTranscript(id, transcript);
            return Ok(new { message = "Transcript updated" });
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var deletedTranscript = await _transcriptService.GetTranscriptById(id);
            if (deletedTranscript == null)
                return NotFound(new { message = "Transcript not found." });

            await _transcriptService.DeleteTranscript(id);
            return Ok(new { message = "Transcript deleted" });
        }
    }
}
