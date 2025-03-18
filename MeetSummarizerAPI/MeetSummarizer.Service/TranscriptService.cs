using AutoMapper;
using MeetSummarizer.Core.DTOs;
using MeetSummarizer.Core.Entities;
using MeetSummarizer.Core.IRepository;
using MeetSummarizer.Core.Repository;
using MeetSummarizer.Core.Services;
using MeetSummarizer.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetSummarizer.Service
{
    public class TranscriptService: ITranscriptService
    {
        private readonly IManagerRepository _managerRepository;

        public TranscriptService(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public async Task<List<Transcript>> GetAllTranscripts()
        {
            return await _managerRepository.transcriptRepository.GetAllTranscriptsAsync();
        }

        public async Task<Transcript> GetTranscriptById(int id)
        {
            return await _managerRepository.transcriptRepository.GetTranscriptByIdAsync(id);
        }

        public async Task AddTranscript(Transcript transcript)
        {
            await _managerRepository.transcriptRepository.AddTranscriptAsync(transcript);
            await _managerRepository.SaveAsync();
        }

        public async Task UpdateTranscript(int id, Transcript transcript)
        {
            await _managerRepository.transcriptRepository.UpdateTranscriptAsync(id, transcript);
            await _managerRepository.SaveAsync();
        }

        public async Task DeleteTranscript(int id)
        {
            await _managerRepository.transcriptRepository.DeleteTranscriptAsync(id);
            await _managerRepository.SaveAsync();
        }
    }
}
