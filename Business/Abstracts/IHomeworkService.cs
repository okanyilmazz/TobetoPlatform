﻿using System;
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
    public interface IHomeworkService
    {
        Task<CreatedHomeworkResponse> AddAsync(CreateHomeworkRequest createHomeworkRequest);
        Task<DeletedHomeworkResponse> DeleteAsync(DeleteHomeworkRequest deleteHomeworkRequest);
        Task<UpdatedHomeworkResponse> UpdateAsync(UpdateHomeworkRequest updateHomeworkRequest);
        Task<IPaginate<GetListHomeworkResponse>> GetListAsync();
        Task<IPaginate<GetListHomeworkResponse>> GetByAccountIdAsync(Guid id);
        Task<GetListHomeworkResponse> GetByIdAsync(Guid id);
    }
}
