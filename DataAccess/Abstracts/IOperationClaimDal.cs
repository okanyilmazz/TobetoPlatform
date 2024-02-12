using Core.DataAccess.Repositories;
using Core.Entities;

namespace DataAccess.Abstracts;

public interface IOperationClaimDal:IRepository<OperationClaim,Guid>, IAsyncRepository<OperationClaim,Guid>
{
}
