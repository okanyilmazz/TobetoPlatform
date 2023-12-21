using System;
namespace Business.Dtos.Responses.GetListResponses;

	public class GetListExamQuestionResponse
	{
        public Guid QuestionId { get; set; }
        public Guid ExamId { get; set; }
    }

