﻿using Business.Abstracts;
using Business.Concrete;
using Business.Concretes;
using Business.Rules;
using Core.Business.Rules;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using DataAccess.Concretes;
using Entities.Concretes;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Business;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddScoped<IAuthService, AuthManager>();
        services.AddScoped<ITokenHelper, JwtHelper>();
        services.AddScoped<IAccountService, AccountManager>();
        services.AddScoped<IAccountAnswerService, AccountAnswerManager>();
        services.AddScoped<IAccountHomeworkService, AccountHomeworkManager>();
        services.AddScoped<IAccountLanguageService, AccountLanguageManager>();
        services.AddScoped<IAccountLessonService, AccountLessonManager>();
        services.AddScoped<IAccountOccupationClassService, AccountOccupationClassManager>();
        services.AddScoped<IAccountSessionService, AccountSessionManager>();
        services.AddScoped<IAccountSkillService, AccountSkillManager>();
        services.AddScoped<IAccountSocialMediaService, AccountSocialMediaManager>();
        services.AddScoped<IAccountUniversityService, AccountUniversityManager>();
        services.AddScoped<IAddressService, AddressManager>();
        services.AddScoped<IAnnouncementService, AnnouncementManager>();
        services.AddScoped<IAnnouncementProjectService, AnnouncementProjectManager>();
        services.AddScoped<IBlogService, BlogManager>();
        services.AddScoped<ICertificateService, CertificateManager>();
        services.AddScoped<ICityService, CityManager>();
        services.AddScoped<IContactService, ContactManager>();
        services.AddScoped<ICountryService, CountryManager>();
        services.AddScoped<IDegreeTypeService, DegreeTypeManager>();
        services.AddScoped<IDistrictService, DistrictManager>();
        services.AddScoped<IEducationProgramService, EducationProgramManager>();
        services.AddScoped<IEducationProgramLessonService, EducationProgramLessonManager>();
        services.AddScoped<IEducationProgramLevelService, EducationProgramLevelManager>();
        services.AddScoped<IEducationProgramOccupationClassService, EducationProgramOccupationClassManager>();
        services.AddScoped<IEducationProgramProgrammingLanguageService, EducationProgramProgrammingLanguageManager>();
        services.AddScoped<IExamService, ExamManager>();
        services.AddScoped<IExamOccupationClassService, ExamOccupationClassManager>();
        services.AddScoped<IExamQuestionService, ExamQuestionManager>();
        services.AddScoped<IExamQuestionTypeService, ExamQuestionTypeManager>();
        services.AddScoped<IExamResultService, ExamResultManager>();
        services.AddScoped<IHomeworkService, HomeworkManager>();
        services.AddScoped<ILanguageService, LanguageManager>();
        services.AddScoped<ILanguageLevelService, LanguageLevelManager>();
        services.AddScoped<ILessonService, LessonManager>();
        services.AddScoped<ILessonCategoryService, LessonCategoryManager>();
        services.AddScoped<ILessonModuleService, LessonModuleManager>();
        services.AddScoped<ILessonSubTypeService, LessonSubTypeManager>();
        services.AddScoped<ILessonSubjectService, LessonSubjectManager>();
        services.AddScoped<IMediaNewService, MediaNewManager>();
        services.AddScoped<IOccupationClassService, OccupationClassManager>();
        services.AddScoped<IOccupationClassSurveyService, OccupationClassSurveyManager>();
        services.AddScoped<IProductionCompanyService, ProductionCompanyManager>();
        services.AddScoped<IProgrammingLanguageService, ProgrammingLanguageManager>();
        services.AddScoped<IProjectService, ProjectManager>();
        services.AddScoped<IQuestionService, QuestionManager>();
        services.AddScoped<IQuestionTypeService, QuestionTypeManager>();
        services.AddScoped<ISessionService, SessionManager>();
        services.AddScoped<ISkillService, SkillManager>();
        services.AddScoped<ISocialMediaService, SocialMediaManager>();
        services.AddScoped<ISurveyService, SurveyManager>();
        services.AddScoped<IUniversityService, UniversityManager>();
        services.AddScoped<IUniversityDepartmentService, UniversityDepartmentManager>();
        services.AddScoped<IUserService, UserManager>();
        services.AddScoped<IWorkExperienceService, WorkExperienceManager>();



        services.AddAutoMapper(Assembly.GetExecutingAssembly());
        services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BaseBusinessRules));
        return services;

    }

    public static IServiceCollection AddSubClassesOfType(
        this IServiceCollection services,
        Assembly assembly,
        Type type,
        Func<IServiceCollection, Type, IServiceCollection>? addWithLifeCycle = null)
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