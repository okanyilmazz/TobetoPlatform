using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ILanguageService
    {
        Task<CreatedLanguageResponse> AddAsync(CreateLanguageRequest createLanguageRequest);
        Task<UpdatedLanguageResponse> UpdateAsync(UpdateLanguageRequest updateLanguageRequest);
        Task<DeletedLanguageResponse> DeleteAsync(DeleteLanguageRequest deleteLanguageRequest);
        Task<IPaginate<GetListLanguageResponse>> GetListAsync();
        Task<GetListLanguageResponse> GetByIdAsync(Guid id);
        Task<IPaginate<GetListLanguageResponse>> GetByAccountIdAsync(Guid id);
    }
}
