using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Address : Entity<Guid>
    {
        public Guid CityId { get; set; }
        public Guid CountryId { get; set; }
        public Guid DistrictId { get; set; }
        public string AddressDetail { get; set; }

        public City City { get; set; }
        public Country Country { get; set; }
        public District District { get; set; }
    }
}
