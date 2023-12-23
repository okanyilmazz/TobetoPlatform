using Business.Abstracts;
using Business.Concretes;
using Business.Rules;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<ILessonService, LessonManager>();
        services.AddScoped<ICertificateService, CertificateManager>();
        services.AddScoped<IEducationProgramLevelService, EducationProgramLevelManager>();
        services.AddScoped<ILessonCategoryService, LessonCategoryManager>();
        services.AddScoped<ILessonSubTypeService, LessonSubTypeManager>();
        services.AddScoped<ILessonSubjectService, LessonSubjectManager>();
        services.AddScoped<IEducationProgramService, EducationProgramManager>();
        services.AddScoped<IAccountUniversityService, AccountUniversityManager>();
        services.AddScoped<ILessonModuleService, LessonModuleManager>();
        services.AddScoped<IAccountLessonService, AccountLessonManager>();
        services.AddScoped<ISessionService, SessionManager>();
        services.AddScoped<ILanguageService, LanguageManager>();
        services.AddScoped<IAccountLanguageService, AccountLanguageManager>();
        services.AddScoped<IHomeworkService, HomeworkManager>();
        services.AddScoped<IEducationProgramProgrammingLanguageService, EducationProgramProgrammingLanguageManager>();
        services.AddScoped<IDegreeTypeService, DegreeTypeManager>();
        services.AddScoped<IAccountAnswerService, AccountAnswerManager>();
        services.AddScoped<IExamService, ExamManager>();
        services.AddScoped<IQuestionService, QuestionManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IProjectService, ProjectManager>();
        services.AddScoped<ICityService, CityManager>();
        services.AddScoped<IEducationProgramOccupationClassService, EducationProgramOccupationClassManager>();
        services.AddScoped<IOccupationClassSurveyService, OccupationClassSurveyManager>();
        services.AddScoped<ILanguageLevelService, LanguageLevelManager>();
        services.AddScoped<IQuestionTypeService, QuestionTypeManager>();
        services.AddScoped<IExamResultService, ExamResultManager>();
        services.AddScoped<IProductionCompanyService, ProductionCompanyManager>();
        services.AddScoped<IBlogService, BlogManager>();
        services.AddScoped<ISkillService, SkillManager>();
        services.AddScoped<ISurveyService, SurveyManager>();
        services.AddScoped<IWorkExperienceService, WorkExperienceManager>();
        services.AddScoped<IAccountOccupationClassService, AccountOccupationClassManager>();
        services.AddScoped<IAccountSocialMediaService, AccountSocialMediaManager>();
        services.AddScoped<IDistrictService, DistrictManager>();
        services.AddScoped<IAccountHomeworkService, AccountHomeworkManager>();
        services.AddScoped<IAnnouncementProjectService, AnnouncementProjectManager>();
        services.AddScoped<IAccountSessionService, AccountSessionManager>();
        services.AddScoped<IAccountService, AccountManager>();
        services.AddScoped<IAccountSkillService, AccountSkillManager>();
        services.AddScoped<IContactService, ContactManager>();
        services.AddScoped<IMediaNewService, MediaNewManager>();
        services.AddScoped<IUniversityService, UniversityManager>();
        services.AddScoped<IEducationProgramLessonService, EducationProgramLessonManager>();
        services.AddScoped<IExamQuestionTypeService, ExamQuestionTypeManager>();
        services.AddScoped<IProgrammingLanguageService, ProgrammingLanguageManager>();
        services.AddScoped<IUniversityDepartmentService, UniversityDepartmentManager>();
        services.AddScoped<ISocialMediaService, SocialMediaManager>();
        services.AddScoped<IExamQuestionService, ExamQuestionManager>();
        services.AddScoped<ICountryService, CountryManager>();
        services.AddScoped<IAddressService, AddressManager>();
        services.AddScoped<IExamOccupationClassService, ExamOccupationClassManager>();
        services.AddScoped<IOccupationClassService, OccupationClassManager>();

        services.AddScoped<IExamOccupationClassService, ExamOccupationClassManager>();
        services.AddScoped<IAnnouncementService, AnnouncementManager>();
        services.AddScoped<ContactBusinessRules>();
        services.AddScoped<QuestionBusinessRules>();
        services.AddScoped<AddressBusinessRules>();
        services.AddScoped<AnnouncementProjectBusinessRules>();
        services.AddScoped<CountryBusinessRules>();
        services.AddScoped<LessonSubTypeBusinessRules>();
        services.AddScoped<SkillBusinessRules>();
        services.AddScoped<UniversityBusinessRules>();
        services.AddScoped<UniversityDepartmentBusinessRules>();
        services.AddScoped<SessionBusinessRules>();
        services.AddScoped<SurveyBusinessRules>();
        services.AddScoped<EducationProgramProgrammingLanguageBusinessRules>();
        services.AddScoped<AccountUniversityBusinessRules>();
        services.AddScoped<LessonSubjectBusinessRules>();
        services.AddScoped<DegreeTypeBusinessRules>();
        services.AddScoped<SocialMediaBusinessRules>();
        services.AddScoped<AccountAnswerBusinessRules>();
        services.AddScoped<CertificateBusinessRules>();
        services.AddScoped<AccountSessionBusinessRules>();
        services.AddScoped<EducationProgramOccupationClassBusinessRules>();
        services.AddScoped<OccupationClassSurveyBusinessRules>();
        services.AddScoped<BlogBusinessRules>();
        services.AddScoped<DistrictBusinessRules>();
        services.AddScoped<LanguageBusinessRules>();
        services.AddScoped<LanguageLevelBusinessRules>();
        services.AddScoped<ExamBusinessRules>();
        services.AddScoped<EducationProgramLevelBusinessRules>();
        services.AddScoped<ExamOccupationClassBusinessRules>();
        services.AddScoped<AnnouncementBusinessRules>();
        services.AddScoped<LessonModuleBusinessRules>();
        services.AddScoped<MediaNewBusinessRules>();
        services.AddScoped<ExamResultBusinessRules>();
        services.AddScoped<ProductionCompanyBusinessRules>();
        services.AddScoped<AccountSkillBusinessRules>();
        services.AddScoped<AccountBusinessRules>();
        services.AddScoped<LessonBusinessRules>();
        services.AddScoped<AccountOccupationClassBusinessRules>();
        services.AddScoped<AccountLanguageBusinessRules>();
        services.AddScoped<EducationProgramLessonBusinessRules>();
        services.AddScoped<OccupationClassBusinessRules>();
        services.AddScoped<UserBusinessRules>();
        services.AddScoped<HomeworkBusinessRules>();
        services.AddScoped<CityBusinessRules>();
        services.AddScoped<ExamQuestionTypeBusinessRules>();
        services.AddScoped<AccountLessonBusinessRules>();



        services.AddScoped<LessonCategoryBusinessRules>();
        
        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        return services;
    
    }

    public static IServiceCollection AddSubClassesOfType(
   this IServiceCollection services,
   Assembly assembly,
   Type type,
   Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null
)
    {
        var types = assembly.GetTypes().Where(t => t.IsSubclassOf(type) && type != t).ToList();
        foreach (var item in types)
            if (addWithLifeCycle == null)
                services.AddScoped(item);

            else
                addWithLifeCycle(services, type);
        return services;
    }
}