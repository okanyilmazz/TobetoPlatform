using System;
namespace Business.Dtos.Requests.DeleteRequests;

	public class DeleteExamQuestionRequest
	{
        public Guid QuestionId { get; set; }
        public Guid ExamId { get; set; }
    }

