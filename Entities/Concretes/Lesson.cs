using Core.Entities;

namespace Entities.Concretes
{
    public class Lesson : Entity<Guid>
    {
        public Guid LanguageId { get; set; }
        public Guid LessonSubCategoryId { get; set; }
        public Guid LessonSubTypeId { get; set; }
        public Guid ProductionCompanyId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }

        public ICollection<EducationProgram> EducationPrograms { get; set; }
        public ICollection<Account> Accounts { get; set; }
       
    }
}
