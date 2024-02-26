namespace Business.Dtos.Responses.LessonResponses;

public class GetListLessonResponse
{
    public Guid Id { get; set; }
    public string LanguageName { get; set; }
    public string LessonModuleName { get; set; }
    public string LessonCategoryName { get; set; }
    public string LessonSubTypeName { get; set; }
    public string ProductionCompanyName { get; set; }
    public string Name { get; set; }
    public string LessonPath { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int Duration { get; set; }
}
