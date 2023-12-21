using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Helpers
{
    public static class ExamMapper
    {
        public static DeleteExamQuestionTypeRequest MapToDeleteCategoryProductRequest(Guid examId)
        {
            return new DeleteExamQuestionTypeRequest { ExamId = examId };
        }
    }
}
