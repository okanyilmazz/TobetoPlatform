using System;
namespace Business.Dtos.Requests.CreateRequests
{
	public class CreateExamQuestionRequest
	{
        public Guid QuestionId { get; set; }
        public Guid ExamId { get; set; }
    }
}

