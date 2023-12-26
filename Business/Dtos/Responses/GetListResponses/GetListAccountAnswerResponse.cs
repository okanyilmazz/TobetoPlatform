using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Dtos.Responses.GetListResponses
{
    public class GetListAccountAnswerResponse
    {
        public Guid Id { get; set; }
        public string AccountName { get; set; }
        public string ExamName { get; set; }
        public string QuestionName { get; set; }
        public string GivenAnswer { get; set; }
    }
}
