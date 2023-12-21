namespace Business.Dtos.Responses.GetListResponses
{
    public class GetListUniversityDepartmentResponse
    {
        public Guid Id { get; set; }
        public Guid UniversityId { get; set; }
        public string Name { get; set; }
    }
}