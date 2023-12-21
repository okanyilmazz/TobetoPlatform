using System;
using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

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
            var result = await _certificateDal.GetListAsync(
                predicate: c => c.Id == certificateId
                );
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}

