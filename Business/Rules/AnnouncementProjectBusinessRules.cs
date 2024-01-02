﻿using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class AnnouncementProjectBusinessRules : BaseBusinessRules
    {
        private readonly IAnnouncementProjectDal _announcementProjectDal;

        public AnnouncementProjectBusinessRules(IAnnouncementProjectDal announcementProjectDal)
        {
            _announcementProjectDal = announcementProjectDal;
        }

        public async Task IsExistsAnnouncementProject(Guid announcementProjectId)
        {
            var result = await _announcementProjectDal.GetAsync(
                predicate: a => a.Id == announcementProjectId,
                enableTracking: false);

            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
