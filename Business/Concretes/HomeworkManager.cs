using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class HomeworkManager : IHomeworkService
    {
        IHomeworkDal _homeworkDal;
        IMapper _mapper;

        public HomeworkManager(IHomeworkDal homeworkDal, IMapper mapper)
        {
            _homeworkDal = homeworkDal;
            _mapper = mapper;
        }

        public async Task<CreatedHomeworkResponse> AddAsync(CreateHomeworkRequest createHomeworkRequest)
        {
            Homework homework = _mapper.Map<Homework>(createHomeworkRequest);
            Homework addedHomework = await _homeworkDal.AddAsync(homework);
            CreatedHomeworkResponse createdHomeworkResponse = _mapper.Map<CreatedHomeworkResponse>(addedHomework);
            return createdHomeworkResponse;

        }

        public async Task<DeletedHomeworkResponse> DeleteAsync(DeleteHomeworkRequest deleteHomeworkRequest)
        {
            Homework homework = _mapper.Map<Homework>(deleteHomeworkRequest);
            Homework deletedHomework = await _homeworkDal.DeleteAsync(homework, true);
            DeletedHomeworkResponse deletedHomeworkResponse = _mapper.Map<DeletedHomeworkResponse>(deletedHomework);
            return deletedHomeworkResponse;
        }

        public async Task<IPaginate<GetListHomeworkResponse>> GetByAccountIdAsync(Guid id)
        {
            var homeworks = await _homeworkDal.GetListAsync(
                include: a=>a.Include(a=>a.Accounts));
            var filteredHomeworks = homeworks.Items.SelectMany(h=>h.Accounts.Where(a=>a.Id ==id).Select(a=>h)).ToList();
            var mappedHomeworks = _mapper.Map<Paginate<GetListHomeworkResponse>>(filteredHomeworks);
            return mappedHomeworks;
        }

        public async Task<IPaginate<GetListHomeworkResponse>> GetListAsync()
        {
            var homeworks = await _homeworkDal.GetListAsync();
            var mappedHomeworks = _mapper.Map<Paginate<GetListHomeworkResponse>>(homeworks);
            return mappedHomeworks;
        }

        public async Task<UpdatedHomeworkResponse> UpdateAsync(UpdateHomeworkRequest updateHomeworkRequest)
        {

            Homework homework = _mapper.Map<Homework>(updateHomeworkRequest);
            Homework updatedHomework = await _homeworkDal.UpdateAsync(homework);
            UpdatedHomeworkResponse updatedHomeworkResponse = _mapper.Map<UpdatedHomeworkResponse>(updatedHomework);
            return updatedHomeworkResponse;

        }
    }
}
