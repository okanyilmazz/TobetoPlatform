namespace Business.Dtos.Requests.CreateRequests
{
    public class CreateCityRequest
    {
        public Guid CountryId { get; set; }
        public string Name { get; set; }
    }
}