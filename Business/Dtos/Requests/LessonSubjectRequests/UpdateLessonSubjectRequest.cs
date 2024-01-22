using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.LessonSubjectRequests
{
    public class UpdateLessonSubjectRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
