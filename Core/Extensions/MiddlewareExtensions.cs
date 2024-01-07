using Core.CrossCuttingConcerns.Caching.Microsoft;
using Core.CrossCuttingConcerns.Logging.SeriLog;
using Microsoft.AspNetCore.Builder;

namespace Core.Extensions;

public static class MiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<ExceptionMiddleware>().
        UseMiddleware<ValidationMiddleware>().
        UseMiddleware<CacheMiddleware>().
        UseMiddleware<SeriLogMiddleware>();
}