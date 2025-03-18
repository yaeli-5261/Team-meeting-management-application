using MeetSummarizer.Core.DTOs;
using MeetSummarizer.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetSummarizer.Core.Services
{
    public interface ITranscriptService
    {
        Task<List<Transcript>> GetAllTranscripts();
        Task<Transcript> GetTranscriptById(int id);
        Task AddTranscript(Transcript transcript);
        Task UpdateTranscript(int id, Transcript transcript);
        Task DeleteTranscript(int id);
    }
}
