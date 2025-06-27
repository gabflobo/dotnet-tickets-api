using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets_API.Domain.Entities;
using Tickets_API.Domain.Enums;

namespace Tickets_API.Application.Queries
{
    public record GetTicketsQuery(StatusTicket? Status) : IRequest<IEnumerable<Ticket>> { }
}
