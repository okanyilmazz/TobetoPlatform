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
            var result = await _announcementDal.GetListAsync(a => a.Id == announcementId);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }

    }
}
