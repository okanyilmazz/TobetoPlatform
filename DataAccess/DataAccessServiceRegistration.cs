
using DataAccess.Abstracts;
using DataAccess.Concretes;
using DataAccess.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DataAccess;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<TobetoPlatformContext>(options => options.UseSqlServer(configuration.GetConnectionString("TobetoPlatformContext")));
        //services.AddDbContext<TobetoPlatformContext>(options => options.UseSqlServer(configuration.GetConnectionString("TobetoPlatformContextMAC")));

        services.AddScoped<ILessonDal, EfLessonDal>();
        services.AddScoped<ILessonCategoryDal, EfLessonCategoryDal>();
        services.AddScoped<IEducationProgramLevelDal, EfEducationProgramLevelDal>();
        services.AddScoped<ILessonSubjectDal, EfLessonSubjectDal>();
        services.AddScoped<IEducationProgramDal, EfEducationProgramDal>();
        services.AddScoped<IAccountOccupationClassDal, EfAccountOccupationClassDal>();
        services.AddScoped<ILessonSubTypeDal, EfLessonSubTypeDal>();
        services.AddScoped<IProductionCompanyDal, EfProductionCompanyDal>();
        services.AddScoped<IQuestionTypeDal, EfQuestionTypeDal>();
        services.AddScoped<IExamResultDal, EfExamResultDal>();
        services.AddScoped<IUserDal, EfUserDal>();
        services.AddScoped<IProjectDal, EfProjectDal>();
        services.AddScoped<ILanguageDal, EfLanguageDal>();
        services.AddScoped<ICityDal, EfCityDal>();
        services.AddScoped<IOccupationClassSurveyDal, EfOccupationClassSurveyDal>();
        services.AddScoped<IEducationProgramOccupationClassDal, EfEducationProgramOccupationClassDal>();
        services.AddScoped<IAccountLanguageDal, EfAccountLanguageDal>();
        services.AddScoped<ILanguageLevelDal, EfLanguageLevelDal>();
        services.AddScoped<ILessonModuleDal, EfLessonModuleDal>();
        services.AddScoped<ICertificateDal, EfCertificateDal>();
        services.AddScoped<IAccountUniversityDal, EfAccountUniversityDal>();
        services.AddScoped<IAccountLessonDal, EfAccountLessonDal>();
        services.AddScoped<ISessionDal, EfSessionDal>();
        services.AddScoped<IHomeworkDal, EfHomeworkDal>();
        services.AddScoped<IDegreeTypeDal, EfDegreeTypeDal>();
        services.AddScoped<IEducationProgramProgrammingLanguageDal, EfEducationProgramProgrammingLanguageDal>();
        services.AddScoped<IAccountAnswerDal, EfAccountAnswerDal>();
        services.AddScoped<IExamDal, EfExamDal>();
        services.AddScoped<IQuestionDal, EfQuestionDal>();
        services.AddScoped<ISurveyDal, EfSurveyDal>();
        services.AddScoped<IWorkExperienceDal, EfWorkExperienceDal>();
        services.AddScoped<IAccountSocialMediaDal, EfAccountSocialMediaDal>();
        services.AddScoped<IBlogDal, EfBlogDal>();
        services.AddScoped<ISkillDal, EfSkillDal>();
        services.AddScoped<IDistrictDal, EfDistrictDal>();
        services.AddScoped<IAccountHomeworkDal, EfAccountHomeworkDal>();
        services.AddScoped<IContactDal, EfContactDal>();
        services.AddScoped<IMediaNewDal, EfMediaNewDal>();
        services.AddScoped<IUniversityDal, EfUniversityDal>();
        services.AddScoped<IEducationProgramLessonDal, EfEducationProgramLessonDal>();
        services.AddScoped<IAnnouncementProjectDal, EfAnnouncementProjectDal>();
        services.AddScoped<IAccountSessionDal, EfAccountSessionDal>();
        services.AddScoped<IAccountDal, EfAccountDal>();
        services.AddScoped<IExamQuestionTypeDal, EfExamQuestionTypeDal>();
        services.AddScoped<IProgrammingLanguageDal, EfProgrammingLanguageDal>();
        services.AddScoped<IUniversityDepartmentDal, EfUniversityDepartmentDal>();
        services.AddScoped<ISocialMediaDal, EfSocialMediaDal>();
        services.AddScoped<IExamQuestionDal, EfExamQuestionDal>();
        services.AddScoped<ICountryDal, EfCountryDal>();
        services.AddScoped<IAccountSkillDal, EfAccountSkillDal>();
        services.AddScoped<IAddressDal, EfAddressDal>();
        services.AddScoped<IExamOccupationClassDal, EfExamOccupationClassDal>();
        services.AddScoped<IOccupationClassDal, EfOccupationClassDal>();
        services.AddScoped<ICityDal, EfCityDal>();  
        services.AddScoped<IAnnouncementDal, EfAnnouncementDal>();
        services.AddScoped<IOccupationClassDal, EfOccupationClassDal>();
        services.AddScoped<IEducationProgramOccupationClassDal, EfEducationProgramOccupationClassDal>();
        services.AddScoped<IAccountEducationProgramDal, EfAccountEducationProgramDal>();



        return services;
    }
}
