namespace Business.Dtos.Responses.AddressResponses;

public class GetListAddressResponse
{
    public Guid Id { get; set; }
    public string DistrictName { get; set; }
    public string CityName { get; set; }
    public string CountryName { get; set; }
    public string AddressDetail { get; set; }
}
