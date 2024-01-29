using Core.CrossCuttingConcerns.Caching;
using Core.CrossCuttingConcerns.Logging.SeriLog;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Builder;
using System.Data;

namespace Core.Extensions;

public static class MiddlewareExtensions
{
    public static void ConfigureCustomExceptionMiddleware(this IApplicationBuilder app)
        => app.UseMiddleware<ExceptionMiddleware>().
        UseMiddleware<ValidationMiddleware>().
        UseMiddleware<CacheMiddleware>().
        UseMiddleware<SeriLogMiddleware>().
        UseMiddleware<SecuredOperationMiddleware>();
}