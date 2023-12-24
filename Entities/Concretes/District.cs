using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class District : Entity<Guid>
    {
        public Guid CityId { get; set; }
        public string Name { get; set; }
        public City? Cities { get; set; }
                
    }
}
