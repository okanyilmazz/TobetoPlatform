using Core.DataAccess.Repositories;
using Entities.Concretes;

namespace DataAccess.Abstracts;

public interface IEducationProgramModuleDal : IAsyncRepository<EducationProgramModule, Guid>, IRepository<EducationProgramModule, Guid>
{
}
