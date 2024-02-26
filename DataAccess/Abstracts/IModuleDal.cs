using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IModuleDal : IRepository<Module, Guid>, IAsyncRepository<Module,Guid>
{
}
