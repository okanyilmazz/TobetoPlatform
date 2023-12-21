using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.CreateRequests
{
    public class CreateEducationProgramLessonRequest
    {
        public Guid LessonId { get; set; }
        public Guid EducationProgramId { get; set; }

    }
}
