using Business.Messages;
using Core.Business.Rules;
using DataAccess.Abstracts;

namespace Business.Rules
{
    public class QuestionBusinessRules :BaseBusinessRules

    {
        private readonly IQuestionDal _questionDal;

        public QuestionBusinessRules(IQuestionDal questionDal)
        {
            _questionDal = questionDal;
        }

        public async Task IsExistsQuestion(Guid questionId)
        {
            var result = await _questionDal.GetListAsync(
                predicate: q => q.Id == questionId);
            if (result.Count == 0)
            {
                throw new Exception(BusinessMessages.DataNotFound);
            }
        }
    }
}
