using MediatR;
using Microsoft.AspNetCore.Mvc;
using Yellowtail.Cord.Application.Common.Models;
using Yellowtail.Cord.Application.Features.Members.Commands.AssignMemberToTenant;
using Yellowtail.Cord.Application.Features.Members.Commands.AssignSportToMember;
using Yellowtail.Cord.Application.Features.Members.Commands.DeleteMember;
using Yellowtail.Cord.Application.Features.Members.Commands.UpdateMember;
using Yellowtail.Cord.Application.Features.Members.Queries.GetMemberDetails;
using Yellowtail.Cord.Application.Features.Members.Queries.GetTenantMembers;
using Yellowtail.Cord.Filters;

namespace Yellowtail.Cord.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
public class MemberController : ControllerBase
{
    private readonly IMediator _mediator;

    public MemberController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    //[RequireRole("Admin", "Tenant")]
    public async Task<ActionResult<PaginatedList<MemberDto>>> GetTenantMembers([FromQuery] int page = 1, [FromQuery] int pageSize = 20)
    {
        return await _mediator.Send(new GetTenantMembersQuery(page, pageSize));
    }

    [HttpGet("{id}")]
    //[RequireRole("Admin", "Tenant", "Member")]
    public async Task<ActionResult<MemberDto>> GetMember(Guid id)
    {
        var member = await _mediator.Send(new GetMemberDetailsQuery(id));
        if (member == null) return NotFound();
        return Ok(member);
    }

    [HttpPut("{id}")]
    //[RequireRole("Admin", "Tenant", "Member")]
    public async Task<IActionResult> UpdateMember(Guid id, [FromBody] UpdateMemberCommand command)
    {
        if (id != command.Id) return BadRequest();
        var success = await _mediator.Send(command);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpPut("{id}/tenant/{tenantId}")]
    //[RequireRole("Admin", "Tenant")]
    public async Task<IActionResult> AssignToTenant(Guid id, Guid tenantId)
    {
        var success = await _mediator.Send(new AssignMemberToTenantCommand(id, tenantId));
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpPost("{id}/sports/{sportId}")]
    //[RequireRole("Admin", "Tenant")]
    public async Task<IActionResult> AssignSport(Guid id, Guid sportId)
    {
        var success = await _mediator.Send(new AssignSportToMemberCommand(id, sportId));
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    //[RequireRole("Admin", "Tenant")]
    public async Task<IActionResult> DeleteMember(Guid id)
    {
        var success = await _mediator.Send(new DeleteMemberCommand(id));
        if (!success) return NotFound();
        return NoContent();
    }
}
