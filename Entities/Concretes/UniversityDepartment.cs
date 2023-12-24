using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class UniversityDepartment : Entity<Guid>
    {
        public Guid UniversityId { get; set; }
        public string Name { get; set; }

        public University University { get; set; }
    }
}
