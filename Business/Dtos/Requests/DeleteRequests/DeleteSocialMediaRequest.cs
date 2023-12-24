using System;
using Entities.Concretes;

namespace Business.Dtos.Requests.DeleteRequests
{
    public class DeleteSocialMediaRequest
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string IconPath { get; set; }
    }
}
