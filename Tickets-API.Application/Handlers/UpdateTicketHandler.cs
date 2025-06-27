using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets_API.Application.Commands;
using Tickets_API.Application.Exceptions;
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

            if (ticket == null)
            {
                throw new NotFoundException($"Chamado não encontrado.");
            }

            if (!string.IsNullOrEmpty(request.Titulo))
                ticket.Titulo = request.Titulo;

            if (!string.IsNullOrEmpty(request.Descricao))
                ticket.Descricao = request.Descricao;

            if (!string.IsNullOrEmpty(request.NomeSolicitante))
                ticket.NomeSolicitante = request.NomeSolicitante;

            ticket.Status = (Domain.Enums.StatusTicket)request.Status;

            await _repository.UpdateAsync(ticket);
            return Unit.Value;
        }
    }
}
