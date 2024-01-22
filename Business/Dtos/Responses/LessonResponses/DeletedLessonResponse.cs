using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.LessonResponses
{
    public class DeletedLessonResponse
    {
        public Guid Id { get; set; }
        public Guid LanguageId { get; set; }
        public Guid LessonModuleId { get; set; }
        public Guid LessonCategoryId { get; set; }
        public Guid LessonSubTypeId { get; set; }
        public Guid ProductionCompanyId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
    }
}
