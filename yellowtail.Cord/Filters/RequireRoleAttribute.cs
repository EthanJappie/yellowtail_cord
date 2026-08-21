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
            context.Result = new ObjectResult(new ProblemDetails 
            { 
                Status = Microsoft.AspNetCore.Http.StatusCodes.Status403Forbidden,
                Title = "Forbidden",
                Detail = "You do not possess the required role to access this resource."
            }) 
            { 
                StatusCode = Microsoft.AspNetCore.Http.StatusCodes.Status403Forbidden 
            };
            return;
        }
    }
}
