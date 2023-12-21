using System;
using Entities.Concretes;

namespace Business.Dtos.Responses.CreatedResponses
{
    public class CreatedSocialMediaResponse
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }

        public virtual ICollection<Account>? Accounts { get; set; }
    }
}
