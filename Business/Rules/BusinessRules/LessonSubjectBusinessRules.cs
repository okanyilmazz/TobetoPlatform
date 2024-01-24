using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules.BusinessRules;

public class LessonSubjectBusinessRules : BaseBusinessRules
{
    private readonly ILessonSubjectDal _lessonSubjectDal;

    public LessonSubjectBusinessRules(ILessonSubjectDal lessonSubjectDal)
    {
        _lessonSubjectDal = lessonSubjectDal;
    }
    public async Task IsExistsLessonSubject(Guid lessonSubjectId)
    {
        var result = await _lessonSubjectDal.GetAsync(
            predicate: l => l.Id == lessonSubjectId,
            enableTracking: false);

        if (result == null)
        {
            throw new BusinessException(BusinessMessages.DataNotFound);
        }
    }
}
