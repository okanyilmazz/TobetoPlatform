﻿using Entities.Concretes;

namespace Business.Dtos.Responses.GetListResponses
{
    public class GetListWorkExperienceResponse
    {
        public Guid Id { get; set; }
        public Guid CityName { get; set; }
        public Guid AccountName { get; set; }
        public string Industry { get; set; }
        public string CompanyName { get; set; }
        public string Department { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Account Account { get; set; }
    }
}
