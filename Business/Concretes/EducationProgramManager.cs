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

        public EducationProgramManager(IEducationProgramDal educationProgramDal, IMapper mapper)
        {
            _educationProgramDal = educationProgramDal;
            _mapper = mapper;
        }

        public async Task<CreatedEducationProgramResponse> AddAsync(CreateEducationProgramRequest createEducationProgramRequest)
        {
            EducationProgram EducationProgram = _mapper.Map<EducationProgram>(createEducationProgramRequest);
            EducationProgram addedEducationProgram = await _educationProgramDal.AddAsync(EducationProgram);
            var mappedEducationProgram = _mapper.Map<CreatedEducationProgramResponse>(addedEducationProgram);
            return mappedEducationProgram;
        }

        public async Task<DeletedEducationProgramResponse> DeleteAsync(DeleteEducationProgramRequest deleteEducationProgramRequest)
        {
            EducationProgram EducationProgram = _mapper.Map<EducationProgram>(deleteEducationProgramRequest);
            EducationProgram deletedEducationProgram = await _educationProgramDal.DeleteAsync(EducationProgram);
            var mappedEducationProgram = _mapper.Map<DeletedEducationProgramResponse>(deletedEducationProgram);
            return mappedEducationProgram;
        }

        public async Task<IPaginate<GetListEducationProgramResponse>> GetListAsync()
        {
            var EducationProgramList = await _educationProgramDal.GetListAsync();
            var mappedEducationProgram = _mapper.Map<Paginate<GetListEducationProgramResponse>>(EducationProgramList);
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
