using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets_API.Application.Commands;
using Tickets_API.Domain.Entities;
using Tickets_API.Domain.Interfaces;

namespace Tickets_API.Application.Handlers
{
    public class CreateTicketHandler : IRequestHandler<CreateTicketCommand, Ticket>
    {
        private readonly ITicketRepository _repository;

        public CreateTicketHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<Ticket> Handle(CreateTicketCommand request, CancellationToken cancellationToken)
        {
            var ticket = new Ticket
            {
                Id = Guid.NewGuid(),
                Titulo = request.Titulo,
                Descricao = request.Descricao,
                NomeSolicitante = request.NomeSolicitante,
                DataCriacao = DateTime.UtcNow,
                Status = Domain.Enums.StatusTicket.Aberto
            };

            await _repository.AddAsync(ticket);
            return ticket;
        }
    }
}
