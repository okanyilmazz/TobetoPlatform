using Business.Dtos.Requests.CreateRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public static class ExamQuestionTypeMapper
    {
        public static CreateExamQuestionTypeRequest MapToCreateExamQuestionRequest(Guid questionTypeId, Guid examId)
        {
            return new CreateExamQuestionTypeRequest { ExamId = examId, QuestionTypeId = questionTypeId };
        }
    }
}
