using Core.BusinessAspects;
using Core.Messages;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Http;
using Core.Extensions;
using Microsoft.AspNetCore.Mvc;

public class SecuredOperationMiddleware
{
    private readonly RequestDelegate _next;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public SecuredOperationMiddleware(RequestDelegate next, IHttpContextAccessor httpContextAccessor)
    {
        _next = next;
        _httpContextAccessor = httpContextAccessor;
    }

    public async Task Invoke(HttpContext context)
    {
        var endpoint = context.Features.Get<IEndpointFeature>()?.Endpoint;
        var securedAttribute = endpoint?.Metadata.GetMetadata<SecuredOperationAttribute>();

        if (securedAttribute != null)
        {
            var requiredRoles = securedAttribute.Roles.Split(',');

            // Kullanıcının rollerini kontrol et
            var userRoleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();

            foreach (var requiredRole in requiredRoles)
            {
                if (userRoleClaims.Contains(requiredRole))
                {
                    await _next(context);
                    return;
                }
            }

            // Kullanıcı gerekli rolleri karşılamıyorsa
            context.Response.StatusCode = 403;
            await context.Response.WriteAsync(CoreMessages.AuthorizationDenied);
        }
        else
        {
            // Attribute yoksa devam et
            await _next(context);
        }
    }
}
