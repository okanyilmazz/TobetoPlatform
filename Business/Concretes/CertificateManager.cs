using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Requests.CertificateRequests;
using Business.Dtos.Responses.CertificateResponses;
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
            Certificate certificate = await _certificateDal.GetAsync(predicate: l => l.Id == deleteCertificateRequest.Id);
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

        public async Task<IPaginate<GetListCertificateResponse>> GetListAsync(PageRequest pageRequest)
        {
            var certificate = await _certificateDal.GetListAsync(
             index: pageRequest.PageIndex,
             size: pageRequest.PageSize);
            var mappedCertificate = _mapper.Map<Paginate<GetListCertificateResponse>>(certificate);
            return mappedCertificate;
        }

        public async Task<GetListCertificateResponse> GetByIdAsync(Guid id)
        {
            var certificate = await _certificateDal.GetAsync(c => c.Id == id);
            var mappedCertificate = _mapper.Map<GetListCertificateResponse>(certificate);
            return mappedCertificate;
        }
    }
}


