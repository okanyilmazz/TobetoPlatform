using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.DeleteRequests
{
    public class DeleteEducationProgramLessonRequest
    {
        public Guid Id { get; set; }
        public Guid LessonId { get; set; }
        public Guid EducationProgramId { get; set; }
    }
}
