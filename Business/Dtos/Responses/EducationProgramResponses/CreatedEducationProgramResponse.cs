﻿namespace Business.Dtos.Responses.EducationProgramResponses;

public class CreatedEducationProgramResponse
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string ThumbnailPath { get; set; }
    public string Duration { get; set; }
    public string AuthorizedPerson { get; set; }
    public decimal Price { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime Deadline { get; set; }

    public Guid EducationProgramLevelId { get; set; }
}
