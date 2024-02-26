using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class EducationProgramModuleBusinessRules : BaseBusinessRules
{
    IEducationProgramModuleDal _educationProgramModuleDal;

    public EducationProgramModuleBusinessRules(IEducationProgramModuleDal educationProgramModuleDal)
    {
        _educationProgramModuleDal = educationProgramModuleDal;
    }

    public async Task IsExistsEducationProgramModule(Guid id)
    {
        var result = await _educationProgramModuleDal.GetAsync(
            predicate: epl => epl.Id == id,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
    public async Task IsExistsEducationProgramModuleByModuleIdAndEducationProgramId(Guid accountId, Guid educationProgramId)
    {
        var result = await _educationProgramModuleDal.GetAsync(
            predicate: l => l.ModuleId == accountId && l.EducationProgramId == educationProgramId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
