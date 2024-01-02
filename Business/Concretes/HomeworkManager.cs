using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CreateRequests;
using Business.Dtos.Requests.DeleteRequests;
using Business.Dtos.Requests.UpdateRequests;
using Business.Dtos.Responses.CreatedResponses;
using Business.Dtos.Responses.DeletedResponses;
using Business.Dtos.Responses.GetListResponses;
using Business.Dtos.Responses.UpdatedResponses;
using Business.Rules;
using Core.DataAccess.Paging;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes
{
    public class HomeworkManager : IHomeworkService
    {
        IHomeworkDal _homeworkDal;
        IMapper _mapper;
        HomeworkBusinessRules _homeworkBusinessRules;

        public HomeworkManager(IHomeworkDal homeworkDal, IMapper mapper, HomeworkBusinessRules homeworkBusinessRules)
        {
            _homeworkDal = homeworkDal;
            _mapper = mapper;
            _homeworkBusinessRules = homeworkBusinessRules;
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
            await _homeworkBusinessRules.IsExistsHomework(deleteHomeworkRequest.Id);
           // Homework homework = _mapper.Map<Homework>(deleteHomeworkRequest);
            Homework homework = await _homeworkDal.GetAsync(predicate: l => l.Id == deleteHomeworkRequest.Id);
            Homework deletedHomework = await _homeworkDal.DeleteAsync(homework);
            DeletedHomeworkResponse deletedHomeworkResponse = _mapper.Map<DeletedHomeworkResponse>(deletedHomework);
            return deletedHomeworkResponse;
        }

        public async Task<IPaginate<GetListHomeworkResponse>> GetByAccountIdAsync(Guid accountId)
        {
            var homeworks = await _homeworkDal.GetListAsync(
                include: a => a.Include(a => a.AccountHomeworks).ThenInclude(ah => ah.Homework));

            var filteredHomeworks = homeworks.Items.Where(e => e.AccountHomeworks.Any(s => s.AccountId == accountId)).ToList();
            var mappedHomeworks = _mapper.Map<Paginate<GetListHomeworkResponse>>(filteredHomeworks);
            return mappedHomeworks;
        }

        public async Task<GetListHomeworkResponse> GetByIdAsync(Guid id)
        {
            var homework = await _homeworkDal.GetAsync(
            predicate: h => h.Id == id,
            include: h => h
            .Include(h => h.OccupationClass));
            

            var mappedHomework = _mapper.Map<GetListHomeworkResponse>(homework);
            return mappedHomework;
        }

        public async Task<IPaginate<GetListHomeworkResponse>> GetListAsync()
        {
            var homework = await _homeworkDal.GetListAsync(
                include: h => h
                .Include(h => h.OccupationClass));
                

            var mappedHomework = _mapper.Map<Paginate<GetListHomeworkResponse>>(homework);
            return mappedHomework;
        }

        public async Task<UpdatedHomeworkResponse> UpdateAsync(UpdateHomeworkRequest updateHomeworkRequest)
        {
            await _homeworkBusinessRules.IsExistsHomework(updateHomeworkRequest.Id);
            Homework homework = _mapper.Map<Homework>(updateHomeworkRequest);
            Homework updatedHomework = await _homeworkDal.UpdateAsync(homework);
            UpdatedHomeworkResponse updatedHomeworkResponse = _mapper.Map<UpdatedHomeworkResponse>(updatedHomework);
            return updatedHomeworkResponse;

        }
    }
}
