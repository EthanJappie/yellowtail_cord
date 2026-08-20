using MediatR;
using Microsoft.AspNetCore.Mvc;
using Yellowtail.Cord.Application.Common.Models;
using Yellowtail.Cord.Application.Features.Sports.Commands.CreateSport;
using Yellowtail.Cord.Application.Features.Sports.Commands.DeleteSport;
using Yellowtail.Cord.Application.Features.Sports.Commands.UpdateSport;
using Yellowtail.Cord.Application.Features.Sports.Queries.GetSports;
using Yellowtail.Cord.Filters;

namespace Yellowtail.Cord.Controllers.v1;

[ApiController]
[Route("api/v1/[controller]")]
//[RequireRole("Admin")] // Only Admins can modify sports
public class SportController : ControllerBase
{
    private readonly IMediator _mediator;

    public SportController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<SportDto>>> GetSports([FromQuery] int page = 1, [FromQuery] int pageSize = 20, CancellationToken cancellationToken = default)
    {
        return await _mediator.Send(new GetSportsQuery(page, pageSize), cancellationToken);
    }

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateSport([FromBody] CreateSportCommand command, CancellationToken cancellationToken = default)
    {
        var id = await _mediator.Send(command, cancellationToken);
        return StatusCode(201, id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSport(Guid id, [FromBody] UpdateSportCommand command, CancellationToken cancellationToken = default)
    {
        if (id != command.Id) return BadRequest();
        var success = await _mediator.Send(command, cancellationToken);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSport(Guid id, CancellationToken cancellationToken = default)
    {
        var success = await _mediator.Send(new DeleteSportCommand(id), cancellationToken);
        if (!success) return NotFound();
        return NoContent();
    }
}
