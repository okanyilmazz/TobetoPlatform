using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class CalendarSession : Entity<Guid>
    {
        public Guid SessionId { get; set; }
        public Guid UserOperationClaimId { get; set; }
        public Session? Session { get; set; }
        public UserOperationClaim? UserOperationClaim { get; set; }

    }
}
