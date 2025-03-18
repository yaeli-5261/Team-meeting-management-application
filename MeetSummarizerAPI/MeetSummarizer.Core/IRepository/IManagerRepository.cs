using MeetSummarizer.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetSummarizer.Core.IRepository
{
    public interface IManagerRepository
    {
        IMeetingRepository meetingRepository { get; }
        ITranscriptRepository transcriptRepository { get; }
        IRoleRepository roleRepository { get; }
        IUserRepository userRepository { get; }
        IUserRoleRepository userRoleRepository { get; }
        Task SaveAsync();
    }

}
