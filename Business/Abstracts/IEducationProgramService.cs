using Business.Dtos.Requests.EducationProgramRequests;
using Business.Dtos.Requests.FilterRequest;
using Business.Dtos.Responses.EducationProgramResponses;
using Core.DataAccess.Paging;
using Core.Entities;
using Entities.Concretes;

namespace Business.Abstracts;

public interface IEducationProgramService
{
    Task<CreatedEducationProgramResponse> AddAsync(CreateEducationProgramRequest createEducationProgramRequest);
    Task<UpdatedEducationProgramResponse> UpdateAsync(UpdateEducationProgramRequest updateEducationProgramRequest);
    Task<DeletedEducationProgramResponse> DeleteAsync(DeleteEducationProgramRequest deleteEducationProgramRequest);
    Task<IPaginate<GetListEducationProgramResponse>> GetListAsync(PageRequest pageRequest);
    Task<IPaginate<GetListEducationProgramResponse>> GetByOccupationClassIdAsync(Guid occupationClassId);
    Task<GetListEducationProgramResponse> GetByIdAsync(Guid id);
    Task<IPaginate<GetListEducationProgramResponse>> GetListByFiltered(EducationProgramFilterRequest educationProgramFilterRequest);
}