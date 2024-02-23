using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.SessionResponses
{
    public class GetListSessionResponse
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string OccupationClassName { get; set; }
        public DateTime StartDate { get; set; }
        public string AccountName{ get; set; }
        public DateTime EndDate { get; set; }
        public string RecordPath { get; set; }
    }
}
