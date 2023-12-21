using System;
using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules;

public class DegreeTypeBusinessRules : BaseBusinessRules
{
    private readonly IDegreeTypeDal _degreeTypeDal;

    public DegreeTypeBusinessRules(IDegreeTypeDal degreeTypeDal)
    {
        _degreeTypeDal = degreeTypeDal;
    }

    public async Task IsExistsDegreeType(Guid degreeTypeId)
    {

        var result = await _degreeTypeDal.GetListAsync(d => d.Id == degreeTypeId);

        if (result == null)
        {
            throw new Exception(BusinessMessages.DataNotFound);
        }
    }
}


