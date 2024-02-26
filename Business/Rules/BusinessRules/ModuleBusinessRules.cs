using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class ModuleBusinessRules : BaseBusinessRules
{
    IModuleDal _moduleDal;

    public ModuleBusinessRules(IModuleDal moduleDal)
    {
        _moduleDal = moduleDal;
    }

    public async Task IsExistsModule(Guid moduleId)
    {
        var result = await _moduleDal.GetAsync(
            predicate: m => m.Id == moduleId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
