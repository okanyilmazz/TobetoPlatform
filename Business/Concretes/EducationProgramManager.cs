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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class EducationProgramManager : IEducationProgramService
    {
        IEducationProgramDal _educationProgramDal;
        IMapper _mapper;
        EducationProgramBusinessRules _educationProgramBusinessRules;

        public EducationProgramManager(IEducationProgramDal educationProgramDal, IMapper mapper, EducationProgramBusinessRules educationProgramBusinessRules)
        {
            _educationProgramDal = educationProgramDal;
            _mapper = mapper;
            _educationProgramBusinessRules = educationProgramBusinessRules;
           
        }

        public async Task<CreatedEducationProgramResponse> AddAsync(CreateEducationProgramRequest createEducationProgramRequest)
        {
            EducationProgram educationProgram = _mapper.Map<EducationProgram>(createEducationProgramRequest);
            EducationProgram addedEducationProgram = await _educationProgramDal.AddAsync(educationProgram);
            var mappedEducationProgram = _mapper.Map<CreatedEducationProgramResponse>(addedEducationProgram);
            return mappedEducationProgram;
        }

        public async Task<DeletedEducationProgramResponse> DeleteAsync(DeleteEducationProgramRequest deleteEducationProgramRequest)
        {
            await _educationProgramBusinessRules.IsExistsEducationProgram(deleteEducationProgramRequest.Id);
            EducationProgram educationProgram = await _educationProgramDal.GetAsync(predicate: ep => ep.Id == deleteEducationProgramRequest.Id);
            EducationProgram deletedEducationProgram = await _educationProgramDal.DeleteAsync(educationProgram);
            DeletedEducationProgramResponse deletedEducationProgramResponse = _mapper.Map<DeletedEducationProgramResponse>(deletedEducationProgram);
            return deletedEducationProgramResponse;
        }

        public async Task<IPaginate<GetListEducationProgramResponse>> GetListAsync()
        {
            var educationProgram = await _educationProgramDal.GetListAsync(
                include: ep => ep
               .Include(ep => ep.EducationProgramLevel));

            var mappedEducationPrograms= _mapper.Map<Paginate<GetListEducationProgramResponse>>(educationProgram);
            return mappedEducationPrograms;
        }

        public async Task<IPaginate<GetListEducationProgramResponse>> GetByOccupationClassIdAsync(Guid occupationClassId)
        {
            var educationProgramList = await _educationProgramDal.GetListAsync(
                include: e => e.Include(o => o.EducationProgramOccupationClasses).ThenInclude(epoc => epoc.OccupationClass));

            var filteredEducationPrograms = educationProgramList
                .Items.Where(e => e.EducationProgramOccupationClasses.Any(s => s.OccupationClassId == occupationClassId)).ToList();
            var mappedEducationProgram = _mapper.Map<Paginate<GetListEducationProgramResponse>>(filteredEducationPrograms);
            return mappedEducationProgram;
        }

        public async Task<UpdatedEducationProgramResponse> UpdateAsync(UpdateEducationProgramRequest updateEducationProgramRequest)
        {
            EducationProgram EducationProgram = _mapper.Map<EducationProgram>(updateEducationProgramRequest);
            EducationProgram updateedEducationProgram = await _educationProgramDal.UpdateAsync(EducationProgram);
            var mappedEducationProgram = _mapper.Map<UpdatedEducationProgramResponse>(updateedEducationProgram);
            return mappedEducationProgram;
        }
    }
}
