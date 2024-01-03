using System;
using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using DataAccess.Concretes;

namespace Business.Rules
{
	public class CertificateBusinessRules:BaseBusinessRules
	{
        private readonly ICertificateDal _certificateDal;

        public CertificateBusinessRules(ICertificateDal certificateDal)
        {
            _certificateDal = certificateDal;
        }

        public async Task IsExistsCertificate(Guid certificateId)
        {
            var result = await _certificateDal.GetAsync(
                predicate: q => q.Id == certificateId, enableTracking: false
                );
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}

