using MeetSummarizer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetSummarizer.Core.Repository
{
    public interface ITranscriptRepository
    {
        Task<List<Transcript>> GetAllTranscriptsAsync();
        Task<Transcript> GetTranscriptByIdAsync(int id);
        Task AddTranscriptAsync(Transcript transcript);
        Task UpdateTranscriptAsync(int id, Transcript transcript);
        Task DeleteTranscriptAsync(int id);
    }
}
