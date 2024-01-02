using Business.Abstracts;
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
    public class AnnouncementBusinessRules : BaseBusinessRules
    {
        IAnnouncementDal _announcementDal;

        public AnnouncementBusinessRules(IAnnouncementDal announcementDal)
        {
            _announcementDal = announcementDal;
        }

        public async Task IsExistsAnnouncement(Guid announcementId)
        {
            var result = await _announcementDal.GetAsync(
                predicate: a => a.Id == announcementId,
                enableTracking: false);
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
