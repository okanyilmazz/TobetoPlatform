using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concretes
{
    public class Account : Entity<Guid>
    {
        public Guid AddressId { get; set; }
        public Guid UserId { get; set; }
        public string PhoneNumber { get; set; }
        public string NationalId { get; set; }
        public string Description { get; set; }
        public DateTime BirthDate { get; set; }
        public string? ProfilePhotoPath { get; set; }

        public User User { get; set; }
        public Address Address { get; set; }
        public virtual ICollection<WorkExperience>? WorkExperiences { get; set; }
        public virtual ICollection<AccountOccupationClass>? AccountOccupationClasses { get; set; }
        public virtual ICollection<AccountSkill>? AccountSkills { get; set; }
        public virtual ICollection<Certificate>? Certificates { get; set; }
        public virtual ICollection<AccountSocialMedia>? AccountSocialMedias { get; set; }
        public virtual ICollection<AccountUniversity>? AccountUniversities { get; set; }
        public virtual ICollection<AccountLanguage>? AccountLanguages { get; set; }
        public virtual ICollection<AccountSession>? AccountSessions { get; set; }
        public virtual ICollection<AccountHomework>? AccountHomeworks { get; set; }
        public virtual ICollection<AccountLesson>? AccountLessons { get; set; }
    }
}
