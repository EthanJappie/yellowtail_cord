using MediatR;
using Microsoft.AspNetCore.Mvc;
using Yellowtail.Cord.Application.Common.Models;
using Yellowtail.Cord.Application.Features.Tenants.Commands.CreateTenant;
using Yellowtail.Cord.Application.Features.Tenants.Commands.DeleteTenant;
using Yellowtail.Cord.Application.Features.Tenants.Commands.UpdateTenant;
using Yellowtail.Cord.Application.Features.Tenants.Queries.GetCurrentTenant;
using Yellowtail.Cord.Filters;

namespace Yellowtail.Cord.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class TenantController : ControllerBase
{
    private readonly IMediator _mediator;

    public TenantController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("current")]
    //[RequireRole("Tenant", "Admin")]
    public async Task<ActionResult<TenantDto>> GetCurrentTenant(CancellationToken cancellationToken = default)
    {
        var tenant = await _mediator.Send(new GetCurrentTenantQuery(), cancellationToken);
        if (tenant == null) return NotFound();
        return Ok(tenant);
    }

    [HttpPut("current")]
    //[RequireRole("Tenant", "Admin")]
    public async Task<IActionResult> UpdateTenant([FromBody] UpdateTenantCommand command, CancellationToken cancellationToken = default)
    {
        var success = await _mediator.Send(command, cancellationToken);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpPost]
    //[RequireRole("Admin")]
    public async Task<ActionResult<Guid>> CreateTenant([FromBody] CreateTenantCommand command, CancellationToken cancellationToken = default)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return StatusCode(201, id);
    }

    [HttpDelete("{id}")]
    //[RequireRole("Admin")]
    public async Task<IActionResult> DeleteTenant(Guid id, CancellationToken cancellationToken = default)
    {
        var success = await _mediator.Send(new DeleteTenantCommand(id), cancellationToken);
        if (!success) return NotFound();
        return NoContent();
    }
}
