namespace Business.Dtos.Requests.DeleteRequests
{
    public class DeleteDistrictRequest
    {
        public Guid Id { get; set; }
        public Guid CityId { get; set; }
        public string Name { get; set; }
    }
}