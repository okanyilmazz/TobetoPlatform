using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.GetListResponses
{
    public class GetListAccountSkillResponse
    {
        public Guid Id { get; set; }
        public string SkillName { get; set; }
        public string AccountName { get; set; }
    }
}
