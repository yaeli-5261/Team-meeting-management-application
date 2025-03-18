using MeetSummarizer.Core.IRepository;
using MeetSummarizer.Core.Repository;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetSummarizer.Data.Repositories
{
    public class ManagerRepository: IManagerRepository
    {
        private readonly DataContext context;
        public IMeetingRepository meetingRepository { get; }
        public ITranscriptRepository transcriptRepository { get; }
        public IRoleRepository roleRepository { get; }
        public IUserRepository userRepository { get; }

        public IUserRoleRepository userRoleRepository { get; }
        public ManagerRepository(DataContext _context
                                , IMeetingRepository _meetingRepository,
                                 ITranscriptRepository _transcriptRepository,
                                 IRoleRepository _roleRepository,
                                 IUserRepository _userRepository,
                                 IUserRoleRepository _userRoleRepository )
        {
            meetingRepository = _meetingRepository;
            transcriptRepository = _transcriptRepository;
            roleRepository = _roleRepository;   
            userRepository = _userRepository;
            context = _context;
            userRoleRepository = _userRoleRepository;
        }

        public async Task SaveAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
