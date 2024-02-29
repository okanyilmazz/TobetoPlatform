﻿namespace Business.Dtos.Responses.SessionResponses
{
    public class CreatedSessionResponse
    {
        public Guid Id { get; set; }
        public Guid OccupationClassId { get; set; }
        public Guid LessonId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string RecordPath { get; set; }

    }
}