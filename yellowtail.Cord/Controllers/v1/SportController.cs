using MediatR;
using Microsoft.AspNetCore.Mvc;
using Yellowtail.Cord.Application.Features.Sports.Commands.CreateSport;
using Yellowtail.Cord.Application.Features.Sports.Commands.DeleteSport;
using Yellowtail.Cord.Application.Features.Sports.Commands.UpdateSport;
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

    [HttpPost]
    public async Task<ActionResult<Guid>> CreateSport([FromBody] CreateSportCommand command)
    {
        var id = await _mediator.Send(command);
        return Ok(id);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateSport(Guid id, [FromBody] UpdateSportCommand command)
    {
        if (id != command.Id) return BadRequest();
        var success = await _mediator.Send(command);
        if (!success) return NotFound();
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteSport(Guid id)
    {
        var success = await _mediator.Send(new DeleteSportCommand(id));
        if (!success) return NotFound();
        return NoContent();
    }
}
