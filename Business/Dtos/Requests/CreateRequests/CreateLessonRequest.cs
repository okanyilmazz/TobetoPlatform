using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.CreateRequests
{
    public class CreateLessonRequest
    {
        public Guid LanguageId { get; set; }
        public Guid LessonSubCategoryId { get; set; }
        public Guid LessonSubTypeId { get; set; }
        public Guid ProductionCompanyId { get; set; }
        public Guid EducationProgramLevelId { get; set; }

        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
    }
}
