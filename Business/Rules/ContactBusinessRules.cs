using Business.Dtos.Requests.CreateRequests;
using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class ContactBusinessRules : BaseBusinessRules
    {
        private readonly IContactDal _contactDal;

        public ContactBusinessRules(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }
        public async Task IsExistsContact(Guid contactId)
        {
            var result = await _contactDal.GetListAsync(
                predicate: c => c.Id == contactId);
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
