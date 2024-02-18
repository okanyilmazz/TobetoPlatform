using Business.Messages;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class CompetenceTestQuestionBusinessRules
{
    ICompetenceTestQuestionDal _competenceTestQuestionDal;

    public CompetenceTestQuestionBusinessRules(ICompetenceTestQuestionDal competenceTestQuestionDal)
    {
        _competenceTestQuestionDal = competenceTestQuestionDal;
    }

    public async Task IsExistsCompetenceTestQuestion(Guid competenceTestQuestionId)
    {
        var result = await _competenceTestQuestionDal.GetAsync(
            predicate: ctq => ctq.Id == competenceTestQuestionId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
