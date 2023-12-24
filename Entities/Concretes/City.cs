using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class City : Entity<Guid>
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<District>? Districts { get; set; }
    }
}
