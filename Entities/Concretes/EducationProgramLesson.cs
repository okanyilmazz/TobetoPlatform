﻿using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class EducationProgramLesson : Entity<Guid>
    {
        public Guid LessonId { get; set; }
        public Guid EducationProgramId { get; set; }

        public Lesson Lesson { get; set; }
        public EducationProgram EducationProgram { get; set; }
    }
}