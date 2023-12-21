using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;

namespace Business.Abstracts
{
    public interface IBlogService
    {
        Task<CreatedBlogResponse> AddAsync(CreateBlogRequest createBlogRequest);
        Task<UpdatedBlogResponse> UpdateAsync(UpdateBlogRequest updateBlogRequest);
        Task<DeletedBlogResponse> DeleteAsync(DeleteBlogRequest deleteBlogRequest);
        Task<IPaginate<GetListBlogResponse>> GetListAsync();
    }
}
