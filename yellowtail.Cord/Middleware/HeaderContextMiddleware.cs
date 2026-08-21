using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Threading.Tasks;
using Yellowtail.Cord.Application.Common.Interfaces;

namespace Yellowtail.Cord.Middleware;

public class HeaderContextMiddleware
{
    private readonly RequestDelegate _next;

    public HeaderContextMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context, ITenantProvider tenantProvider, ICurrentUserProvider currentUserProvider)
    {
        var tenantHeader = context.Request.Headers["X-Tenant-Id"].FirstOrDefault();
        if (Guid.TryParse(tenantHeader, out var tenantId))
        {
            tenantProvider.SetCurrentTenant(tenantId);
        }

        var userHeader = context.Request.Headers["X-User-Id"].FirstOrDefault();
        if (Guid.TryParse(userHeader, out var userId))
        {
            currentUserProvider.SetCurrentUserId(userId);
        }

        await _next(context);
    }
}
