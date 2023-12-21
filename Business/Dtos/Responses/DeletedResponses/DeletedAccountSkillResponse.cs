using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.DeletedResponses
{
    public class DeletedAccountSkillResponse
    {
        public Guid Id { get; set; }
        public Guid SkillId { get; set; }
        public Guid AccountId { get; set; }
    }
}
