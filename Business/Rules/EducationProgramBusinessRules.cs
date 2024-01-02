using System;
using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules;

public class EducationProgramBusinessRules : BaseBusinessRules
{
    IEducationProgramDal _educationProgramDal;

    public EducationProgramBusinessRules(IEducationProgramDal educationProgramDal)
    {
        _educationProgramDal = educationProgramDal;
    }

    public async Task IsExistsEducationProgram(Guid educationProgramId)
    {
        var result = await _educationProgramDal.GetListAsync(ep => ep.Id == educationProgramId);
        if (result.Count == 0)
        {
            throw new Exception(BusinessMessages.DataNotFound);
        }
    }

}
