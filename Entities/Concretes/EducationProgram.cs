﻿using Core.Entities;

namespace Entities.Concretes;

public class EducationProgram : Entity<Guid>
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string ThumbnailPath { get; set; }
    public string Duration { get; set; }
    public string AuthorizedPerson { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime Deadline { get; set; }

    public Guid EducationProgramLevelId { get; set; }

    public EducationProgramLevel EducationProgramLevel { get; set; }
    public virtual ICollection<EducationProgramLesson>? EducationProgramLessons { get; set; }
    public virtual ICollection<EducationProgramOccupationClass>? EducationProgramOccupationClasses { get; set; } 
    public virtual ICollection<EducationProgramProgrammingLanguage>? EducationProgramProgrammingLanguages { get; set; }
}