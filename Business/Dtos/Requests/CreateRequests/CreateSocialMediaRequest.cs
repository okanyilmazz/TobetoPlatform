using System;
using Entities.Concretes;

namespace Business.Dtos.Requests.CreateRequests;

public class CreateSocialMediaRequest
{
    public string Name { get; set; }
    public string IconPath { get; set; }
}