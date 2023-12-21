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

        public virtual ICollection<WorkExperience>? WorkExperiences { get; set; }
        public virtual ICollection<OccupationClass>? OccupationClasses { get; set; }
        public virtual ICollection<Skill>? Skills { get; set; }
        public virtual ICollection<Certificate>? Certificates { get; set; }
        public virtual ICollection<SocialMedia>? SocialMedias { get; set; }
        public virtual ICollection<University>? Universities { get; set; }
        public virtual ICollection<Language>? Languages { get; set; }
        public virtual ICollection<Session>? Sessions { get; set; }
        public virtual ICollection<Homework>? Homeworks { get; set; }
        public virtual ICollection<Lesson>? Lessons { get; set; }

    }
}
