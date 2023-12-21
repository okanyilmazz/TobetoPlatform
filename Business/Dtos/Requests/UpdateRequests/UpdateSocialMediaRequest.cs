using System;
using Entities.Concretes;

namespace Business.Dtos.Requests.UpdateRequests;

public class UpdateSocialMediaRequest
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string IconPath { get; set; }

    public virtual ICollection<Account>? Accounts { get; set; }
}


