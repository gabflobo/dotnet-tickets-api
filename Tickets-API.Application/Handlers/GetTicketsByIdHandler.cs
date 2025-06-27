using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets_API.Application.Queries;
using Tickets_API.Domain.Entities;
using Tickets_API.Domain.Interfaces;

namespace Tickets_API.Application.Handlers
{
    public class GetTicketsByIdHandler : IRequestHandler<GetTicketByIdQuery, Ticket>
    {
        private readonly ITicketRepository _repository;

        public GetTicketsByIdHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<Ticket> Handle(GetTicketByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repository.GetByIdAsync(request.Id);
        }
    }
}
