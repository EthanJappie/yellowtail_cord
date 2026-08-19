using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Yellowtail.Cord.Application.Common.Interfaces;

namespace Yellowtail.Cord.Filters;

[AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
public class RequireRoleAttribute : Attribute, IAuthorizationFilter
{
    private readonly string[] _roles;

    public RequireRoleAttribute(params string[] roles)
    {
        _roles = roles;
    }

    public void OnAuthorization(AuthorizationFilterContext context)
    {
        var roleHeader = context.HttpContext.Request.Headers["X-User-Role"].FirstOrDefault();

        if (string.IsNullOrEmpty(roleHeader) || !_roles.Contains(roleHeader, StringComparer.OrdinalIgnoreCase))
        {
            context.Result = new ForbidResult();
            return;
        }

        // Setup tenant and user providers if they exist in the headers
        var tenantHeader = context.HttpContext.Request.Headers["X-Tenant-Id"].FirstOrDefault();
        if (Guid.TryParse(tenantHeader, out var tenantId))
        {
            var tenantProvider = context.HttpContext.RequestServices.GetService(typeof(ITenantProvider)) as ITenantProvider;
            tenantProvider?.SetCurrentTenant(tenantId);
        }
        
        var userHeader = context.HttpContext.Request.Headers["X-User-Id"].FirstOrDefault();
        if (Guid.TryParse(userHeader, out var userId))
        {
            var userProvider = context.HttpContext.RequestServices.GetService(typeof(ICurrentUserProvider)) as ICurrentUserProvider;
            userProvider?.SetCurrentUserId(userId);
        }
    }
}
