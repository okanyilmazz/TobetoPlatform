﻿namespace Business.Dtos.Requests.AccountRequests;

public class UpdateAccountRequest
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public string PhoneNumber { get; set; }
    public string NationalId { get; set; }
    public string Description { get; set; }
    public DateTime BirthDate { get; set; }
    public string? ProfilePhotoPath { get; set; }
    public Guid OccupationClassId { get; set; }

}