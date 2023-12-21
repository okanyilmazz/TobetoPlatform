using System;
namespace Business.Dtos.Responses.DeletedResponses;

	public class DeletedExamQuestionResponse
	{
        public Guid QuestionId { get; set; }
        public Guid ExamId { get; set; }
    }

