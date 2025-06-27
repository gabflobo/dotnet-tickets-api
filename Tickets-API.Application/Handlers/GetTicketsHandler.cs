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
    public class GetTicketsHandler : IRequestHandler<GetTicketsQuery, IEnumerable<Ticket>>
    {
        private readonly ITicketRepository _repository;

        public GetTicketsHandler(ITicketRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Ticket>> Handle(GetTicketsQuery request, CancellationToken cancellationToken)
        {
            if(request.Status.HasValue)
            {
                return await _repository.GetByStatusAsync(request.Status.Value);
            }
            else
            {
                return await _repository.GetAllAsync();
            }
        }
    }
}
