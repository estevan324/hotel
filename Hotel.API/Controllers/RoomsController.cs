using Hotel.Application.Commands.Rooms;
using Hotel.Domain.Models.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Hotel.API.Controllers;

[ApiController]
[Route("[controller]")]
public class RoomsController(IMediator mediator) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IList<Room>>> GetAll()
    {
        var response = await mediator.Send(new GetAllRoomsQuery());
        return Ok(response.ToList());
    }

    [HttpGet("{id:guid}")]
    public async Task<ActionResult<Room>> GetById(Guid id)
    {
        return Ok();
    }
    
    [HttpPost]
    public async Task<ActionResult<Room>> Insert(CreateRoomCommand command)
    {
        var room = await mediator.Send(command);

        return CreatedAtAction(nameof(GetById), new { id = room.Id }, room);
    }
    
}