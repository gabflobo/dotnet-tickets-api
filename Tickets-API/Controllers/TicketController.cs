using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tickets_API.Application.Commands;
using Tickets_API.Application.Queries;

namespace Tickets_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TicketController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("listagem")]
        public async Task<IActionResult> GetAll()
        {
            var tickets = await _mediator.Send(new GetTicketsQuery());
            return Ok(tickets);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ticket = await _mediator.Send(new GetTicketByIdQuery(id));
            if (ticket == null)
            {
               return NotFound();
            }
                

            return Ok(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateTicketCommand command)
        {
            var ticket = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new {id = ticket.Id}, ticket);
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update(Guid id, [FromBody] UpdateTicketCommand command)
        {
            if (id != command.Id)
            {
               return BadRequest();
            }
                

            await _mediator.Send(command);
            return NoContent();
        }
    }
}
