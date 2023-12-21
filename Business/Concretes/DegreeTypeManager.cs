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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concretes
{
    public class DegreeTypeManager : IDegreeTypeService
    {
        IDegreeTypeDal _degreeTypeDal;
        IMapper _mapper;
        DegreeTypeBusinessRules _degreeTypeBusinessRules;

        public DegreeTypeManager(IDegreeTypeDal degreeTypeDal, IMapper mapper, DegreeTypeBusinessRules degreeTypeBusinessRules)
        {
            _degreeTypeDal = degreeTypeDal;
            _mapper = mapper;
            _degreeTypeBusinessRules = degreeTypeBusinessRules;
        }

        public async Task<CreatedDegreeTypeResponse> AddAsync(CreateDegreeTypeRequest createDegreeTypeRequest)
        {
            DegreeType degreeType = _mapper.Map<DegreeType>(createDegreeTypeRequest);
            DegreeType addeddegreeType = await _degreeTypeDal.AddAsync(degreeType);
            CreatedDegreeTypeResponse createddegreeTypeResponse =
            _mapper.Map<CreatedDegreeTypeResponse>(addeddegreeType);
            return createddegreeTypeResponse;
        }

        public async Task<DeletedDegreeTypeResponse> DeleteAsync(DeleteDegreeTypeRequest deleteDegreeTypeRequest)
        {
            await _degreeTypeBusinessRules.IsExistsDegreeType(deleteDegreeTypeRequest.Id);
            DegreeType degreeType = _mapper.Map<DegreeType>(deleteDegreeTypeRequest);
            DegreeType deleteddegreeType = await _degreeTypeDal.DeleteAsync(degreeType, true);
            DeletedDegreeTypeResponse deleteddegreeTypeResponse =
            _mapper.Map<DeletedDegreeTypeResponse>(deleteddegreeType);
            return deleteddegreeTypeResponse;
        }

        public async Task<GetListDegreeTypeResponse> GetByIdAsync(Guid id)
        {
            var degreeTypes = await _degreeTypeDal.GetAsync(d => d.Id == id);
            var mappeddegreeTypes = _mapper.Map<GetListDegreeTypeResponse>(degreeTypes);
            return mappeddegreeTypes;
        }

        public async Task<IPaginate<GetListDegreeTypeResponse>> GetListAsync()
        {
            var degreeTypes = await _degreeTypeDal.GetListAsync();
            var mappeddegreeTypes = _mapper.Map<Paginate<GetListDegreeTypeResponse>>(degreeTypes);
            return mappeddegreeTypes;
        }

        public async Task<UpdatedDegreeTypeResponse> UpdateAsync(UpdateDegreeTypeRequest updatedegreeTypeRequest)
        {
            await _degreeTypeBusinessRules.IsExistsDegreeType(updatedegreeTypeRequest.Id);
            DegreeType degreeType = _mapper.Map<DegreeType>(updatedegreeTypeRequest);
            DegreeType updateddegreeType = await _degreeTypeDal.UpdateAsync(degreeType);
            UpdatedDegreeTypeResponse updateddegreeTypeResponse = _mapper.Map<UpdatedDegreeTypeResponse>
            (updateddegreeType);
            return updateddegreeTypeResponse;
        }
    }
}