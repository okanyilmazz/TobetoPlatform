namespace Business.Dtos.Requests.CreateRequests
{
    public class CreateDistrictRequest
    {
        public Guid CityId { get; set; }
        public string Name { get; set; }
    }
}