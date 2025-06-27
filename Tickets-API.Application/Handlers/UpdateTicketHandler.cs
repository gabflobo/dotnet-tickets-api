using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets_API.Application.Commands;
using Tickets_API.Domain.Interfaces;

namespace Tickets_API.Application.Handlers
{
    public class UpdateTicketHandler : IRequestHandler<UpdateTicketCommand>
    {
        private readonly ITicketRepository _repository;

        public UpdateTicketHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(UpdateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = await _repository.GetByIdAsync(request.Id);

            if(ticket == null)
            {
                throw new Exception("Chamado não encontrado");
            }

            ticket.Titulo = request.Titulo;
            ticket.Descricao = request.Descricao;
            ticket.NomeSolicitante = request.NomeSolicitante;
            ticket.Status = (Domain.Enums.StatusTicket)request.Status;

            await _repository.UpdateAsync(ticket);
            return Unit.Value;
        }
    }
}
