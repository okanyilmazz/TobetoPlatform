using System;
namespace Business.Dtos.Requests.UpdateRequests;

	public class UpdateExamQuestionRequest
	{
        public Guid QuestionId { get; set; }
        public Guid ExamId { get; set; }
    }

