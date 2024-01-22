namespace Business.Dtos.Responses.AccountResponses;

public class GetListAccountResponse
{
    public Guid Id { get; set; }
    public string CityName { get; set; }
    public string DistrictName { get; set; }
    public string CountryName { get; set; }
    public string UserName { get; set; }
    public string PhoneNumber { get; set; }
    public string NationalId { get; set; }
    public string Description { get; set; }
    public DateTime BirthDate { get; set; }
    public string? ProfilePhotoPath { get; set; }
}