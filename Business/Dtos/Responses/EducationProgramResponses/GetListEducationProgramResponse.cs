using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.EducationProgramResponses
{
    public class GetListEducationProgramResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string ThumbnailPath { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime Deadline { get; set; }
        public string EducationProgramLevelName { get; set; }
    }
}
