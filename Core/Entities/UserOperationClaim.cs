using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class UserOperationClaim : Entity<Guid>
    {

        public Guid UserId { get; set; }

        public Guid OperationClaimId { get; set; }
    }
}
