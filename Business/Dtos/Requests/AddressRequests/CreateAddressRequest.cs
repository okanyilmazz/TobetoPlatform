﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Requests.AddressRequests
{
    public class CreateAddressRequest
    {
        public Guid? CityId { get; set; }
        public Guid? CountryId { get; set; }
        public Guid? DistrictId { get; set; }
        public string? AddressDetail { get; set; }
    }
}
