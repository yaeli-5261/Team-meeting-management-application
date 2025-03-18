using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeetSummarizer.Core.DTOs
{
    //UPDATE
    public class TranscriptPutDTO
    {
        public string FileLink { get; set; }
    }

    public class TranscriptDTO
    {
        public int MeetingId { get; set; }
        public string FileLink { get; set; }
    }

}
