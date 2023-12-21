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
    public class CertificateManager : ICertificateService
    {
        ICertificateDal _certificateDal;
        IMapper _mapper;
        CertificateBusinessRules _certificateBusinessRules;

        public CertificateManager(ICertificateDal certificateDal, IMapper mapper, CertificateBusinessRules certificateBusinessRules)
        {
            _certificateDal = certificateDal;
            _mapper = mapper;
            _certificateBusinessRules = certificateBusinessRules;
        }

        public async Task<CreatedCertificateResponse> AddAsync(CreateCertificateRequest createCertificateRequest)
        {
            Certificate certificate = _mapper.Map<Certificate>(createCertificateRequest);
            Certificate addedCertificate = await _certificateDal.AddAsync(certificate);
            CreatedCertificateResponse createdCertificateResponse = _mapper.Map<CreatedCertificateResponse>(addedCertificate);
            return createdCertificateResponse;

        }

        public async Task<DeletedCertificateResponse> DeleteAsync(DeleteCertificateRequest deleteCertificateRequest)
        {
            await _certificateBusinessRules.IsExistsCertificate(deleteCertificateRequest.Id);
            Certificate certificate = _mapper.Map<Certificate>(deleteCertificateRequest);
            Certificate deletedCertificate = await _certificateDal.DeleteAsync(certificate);
            DeletedCertificateResponse deletedCertificateResponse = _mapper.Map<DeletedCertificateResponse>(deletedCertificate);
            return deletedCertificateResponse;
        }
        public async Task<UpdatedCertificateResponse> UpdateAsync(UpdateCertificateRequest updateCertificateRequest)
        {
            await _certificateBusinessRules.IsExistsCertificate(updateCertificateRequest.Id);
            Certificate certificate = _mapper.Map<Certificate>(updateCertificateRequest);
            Certificate updatedCertificate = await _certificateDal.UpdateAsync(certificate);
            UpdatedCertificateResponse updatedCertificateResponse = _mapper.Map<UpdatedCertificateResponse>(updatedCertificate);
            return updatedCertificateResponse;
        }

        public async Task<IPaginate<GetListCertificateResponse>> GetListAsync()
        {
            var Certificate = await _certificateDal.GetListAsync();
            var mappedCertificate = _mapper.Map<Paginate<GetListCertificateResponse>>(Certificate);
            return mappedCertificate;
        }


    }
}


