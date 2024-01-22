using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.EducationProgramLessonResponses
{
    public class GetListEducationProgramLessonResponse
    {
        public Guid Id { get; set; }
        public string LessonName { get; set; }
        public string EducationProgramName { get; set; }
    }
}
