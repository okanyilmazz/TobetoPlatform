using Business.Dtos.Requests.QuestionRequests;
using Business.Dtos.Responses.QuestionResponses;
using Core.DataAccess.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface IQuestionService
    {
        Task<CreatedQuestionResponse> AddAsync(CreateQuestionRequest createQuestionRequest);
        Task<UpdatedQuestionResponse> UpdateAsync(UpdateQuestionRequest updateQuestionRequest);
        Task<DeletedQuestionResponse> DeleteAsync(DeleteQuestionRequest deleteQuestionRequest);
        Task<IPaginate<GetListQuestionResponse>> GetListAsync(PageRequest pageRequest);
        Task<GetListQuestionResponse> GetByIdAsync(Guid id);
        Task<IPaginate<GetListQuestionResponse>> GetByExamIdAsync(Guid Id);
    }
}
