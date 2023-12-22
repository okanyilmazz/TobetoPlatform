using Business.Messages;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class BlogBusinessRules
    {
        private readonly IBlogDal _blogDal;

        public BlogBusinessRules(IBlogDal blogDal)
        {
            _blogDal = blogDal;
        }

        public async Task IsExistsBlog(Guid BlogId)
        {
            var result = await _blogDal.GetListAsync(
                predicate: q => q.Id == BlogId
                );
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}