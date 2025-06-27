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
    public class DeleteTicketHandler : IRequestHandler<DeleteTicketCommand>
    {
        private readonly ITicketRepository _repository;

        public DeleteTicketHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTicketCommand request, CancellationToken cancellationToken)
        {
            await _repository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
