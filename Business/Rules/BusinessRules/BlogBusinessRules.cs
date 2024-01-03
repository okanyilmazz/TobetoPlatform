using Business.Messages;
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
    public class BlogBusinessRules : BaseBusinessRules
    {
        private readonly IBlogDal _blogDal;

        public BlogBusinessRules(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public async Task IsExistsBlog(Guid blogId)
        {
            var result = await _blogDal.GetAsync(
                predicate: q => q.Id == blogId, enableTracking: false
                );
            if (result == null)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}