using Core.DataAccess.Repositories;
using Core.Entities;
using DataAccess.Abstracts;
using DataAccess.Contexts;

namespace DataAccess.Concretes;

public class EfOperationClaimDal : EfRepositoryBase<OperationClaim, Guid, TobetoPlatformContext>, IOperationClaimDal
{
    public EfOperationClaimDal(TobetoPlatformContext context) : base(context)
    {
    }
}
