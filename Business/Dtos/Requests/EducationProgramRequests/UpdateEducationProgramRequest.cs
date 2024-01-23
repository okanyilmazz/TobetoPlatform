using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.EducationProgramRequests
{
    public class UpdateEducationProgramRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ThumbnailPath { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public Guid EducationProgramLevelId { get; set; }
    }
}
