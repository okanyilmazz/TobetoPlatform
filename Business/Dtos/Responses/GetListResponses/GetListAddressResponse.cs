using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.GetListResponses
{
    public class GetListAddressResponse
    {
        public Guid Id { get; set; }
        public string DistrictName { get; set; }
        public string CityName { get; set; }
        public string CountryName { get; set; }
        public string AddressDetail { get; set; }
    }
}
