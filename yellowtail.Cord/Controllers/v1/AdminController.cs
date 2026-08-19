using MediatR;
using Microsoft.AspNetCore.Mvc;
using Yellowtail.Cord.Application.Common.Models;
using Yellowtail.Cord.Application.Features.Admin.Queries.GetGlobalMembers;
using Yellowtail.Cord.Application.Features.Admin.Queries.GetTenants;
using Yellowtail.Cord.Filters;

namespace Yellowtail.Cord.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
[RequireRole("Admin")] // Only Admins can access endpoints in this controller
public class AdminController : ControllerBase
{
    private readonly IMediator _mediator;

    public AdminController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("tenants")]
    public async Task<ActionResult<PaginatedList<TenantDto>>> GetTenants([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        return await _mediator.Send(new GetTenantsQuery(page, pageSize));
    }

    [HttpGet("members")]
    public async Task<ActionResult<PaginatedList<MemberDto>>> GetMembers([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        return await _mediator.Send(new GetGlobalMembersQuery(page, pageSize));
    }
}
