using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.GetListResponses
{
    public class GetListAccountUniversityResponse
    {
        public Guid Id { get; set; }
        public Guid DegreeTypeId { get; set; }
        public Guid UniversityId { get; set; }
        public Guid UniversityDepartmentId { get; set; }

    }
}
