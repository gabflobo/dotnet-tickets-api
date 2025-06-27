using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tickets_API.Application.Commands;
using Tickets_API.Application.Queries;
using Tickets_API.Domain.Enums;

namespace Tickets_API.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> GetAll([FromQuery] StatusTicket? status)
        {
            var tickets = await _mediator.Send(new GetTicketsQuery(status));
            return Ok(new
            {
                message = "Lista de chamados obtida com sucesso",
                data = tickets
            });
        }

        [HttpGet("detalhes/{id}")]
        public async Task<IActionResult> GetById(Guid id)
        {
            var ticket = await _mediator.Send(new GetTicketByIdQuery(id));
            if (ticket == null)
            {
               return NotFound();
            }

            return Ok(new
            {
                message = "Chamado obtido com sucesso",
                data = ticket
            });
        }

        [HttpPost("criar")]
        public async Task<IActionResult> Create([FromBody] CreateTicketCommand command)
        {
            var ticket = await _mediator.Send(command);
            return CreatedAtAction(nameof(GetById), new {id = ticket.Id}, new
            {
                message = "Chamado criado com sucesso!",
                data = ticket
            });
        }


        [HttpPut("atualizar")]
        public async Task<IActionResult> Update([FromBody] UpdateTicketCommand command)
        {
            await _mediator.Send(command);
            return Ok(new { message = "Chamado atualizado com sucesso" });
        }

        [HttpDelete("remover/{id}")]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _mediator.Send(new DeleteTicketCommand(id));
            return Ok(new { message = "Chamado excluído com sucesso" });
        }
    }
}
