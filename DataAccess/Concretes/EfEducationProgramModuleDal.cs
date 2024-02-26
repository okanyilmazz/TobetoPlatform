using Core.DataAccess.Repositories;
using DataAccess.Abstracts;
using DataAccess.Contexts;
using Entities.Concretes;

namespace DataAccess.Concretes
{
    public class EfEducationProgramModuleDal : EfRepositoryBase<EducationProgramModule, Guid, TobetoPlatformContext>, IEducationProgramModuleDal
    {
        public EfEducationProgramModuleDal(TobetoPlatformContext context) : base(context)
        {
        }
    }
}
