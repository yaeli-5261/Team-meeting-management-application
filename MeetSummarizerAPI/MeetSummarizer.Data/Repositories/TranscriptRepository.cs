using MeetSummarizer.Core.Entities;
using MeetSummarizer.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static MeetSummarizer.Data.Repositories.TranscriptRepository;

namespace MeetSummarizer.Data.Repositories
{
    public class TranscriptRepository : ITranscriptRepository
    {
        private readonly DataContext _context;
        public TranscriptRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<List<Transcript>> GetAllTranscriptsAsync()
        {
            return await _context.Transcripts.ToListAsync();
        }

        public async Task<Transcript> GetTranscriptByIdAsync(int id)
        {
            return await _context.Transcripts.FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddTranscriptAsync(Transcript transcript)
        {
            await _context.Transcripts.AddAsync(transcript);
        }

        public async Task UpdateTranscriptAsync(int id, Transcript transcript)
        {
            var transcriptToUpdate = await GetTranscriptByIdAsync(id);
            if (transcriptToUpdate == null)
            {
                throw new KeyNotFoundException($"Transcript with id {id} not found");
            }
            transcriptToUpdate.MeetingId = transcript.MeetingId;
            transcriptToUpdate.FileLink = transcript.FileLink;
        }

        public async Task DeleteTranscriptAsync(int id)
        {
            var transcript = await GetTranscriptByIdAsync(id);
            if (transcript != null)
                _context.Transcripts.Remove(transcript);
        }
    }

}
