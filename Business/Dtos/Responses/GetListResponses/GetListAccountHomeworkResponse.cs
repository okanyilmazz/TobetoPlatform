using Entities.Concretes;

namespace Business.Dtos.Responses.GetListResponses
{
    public class GetListAccountHomeworkResponse
    {
        public Guid Id { get; set; }
        public string HomeworkName { get; set; }
        public string AccountName { get; set; }
        public bool Status { get; set; }
    }
}