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
    public class MediaNewManager : IMediaNewService
    {
        IMediaNewDal _mediaNewDal;
        IMapper _mapper;
        MediaNewBusinessRules _mediaNewBusinessRules;

        public MediaNewManager(IMediaNewDal mediaNewDal, IMapper mapper)
        {
            _mediaNewDal = mediaNewDal;
            _mapper = mapper;
        }

        public async Task<CreatedMediaNewResponse> AddAsync(CreateMediaNewRequest createMediaNewRequest)
        {
            MediaNew mediaNew = _mapper.Map<MediaNew>(createMediaNewRequest);
            MediaNew addedMediaNew = await _mediaNewDal.AddAsync(mediaNew);
            CreatedMediaNewResponse createdMediaNewResponse = _mapper.Map<CreatedMediaNewResponse>(addedMediaNew);
            return createdMediaNewResponse;
        }

        public async Task<DeletedMediaNewResponse> DeleteAsync(DeleteMediaNewRequest deleteMediaNewRequest)
        {
            await _mediaNewBusinessRules.IsExistsMediaNew(deleteMediaNewRequest.Id);
            MediaNew mediaNew = _mapper.Map<MediaNew>(deleteMediaNewRequest);
            MediaNew deletedMediaNew = await _mediaNewDal.DeleteAsync(mediaNew);
            DeletedMediaNewResponse deletedMediaNewResponse = _mapper.Map<DeletedMediaNewResponse>(deletedMediaNew);
            return deletedMediaNewResponse;
        }

        public async Task<GetListMediaNewResponse> GetByIdAsync(Guid id)
        {
            var mediaNewId = await _mediaNewDal.GetAsync(m => m.Id == id);
            var mappedMediaNew = _mapper.Map<GetListMediaNewResponse>(mediaNewId);
            return mappedMediaNew;
        }

        public async Task<IPaginate<GetListMediaNewResponse>> GetListAsync()
        {
            var mediaNew = await _mediaNewDal.GetListAsync();
            var mappedMediaNew = _mapper.Map<Paginate<GetListMediaNewResponse>>(mediaNew);
            return mappedMediaNew;
        }

        public async Task<UpdatedMediaNewResponse> UpdateAsync(UpdateMediaNewRequest updateMediaNewRequest)
        {
            await _mediaNewBusinessRules.IsExistsMediaNew(updateMediaNewRequest.Id);
            MediaNew mediaNew = _mapper.Map<MediaNew>(updateMediaNewRequest);
            MediaNew updatedMediaNew = await _mediaNewDal.UpdateAsync(mediaNew);
            UpdatedMediaNewResponse updatedMediaNewResponse = _mapper.Map<UpdatedMediaNewResponse>(updatedMediaNew);
            return updatedMediaNewResponse;
        }
    }
}
