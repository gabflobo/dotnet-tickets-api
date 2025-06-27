using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_API.Application.Commands
{
    public class DeleteTicketCommand :IRequest
    {
        public Guid Id { get; set; }

        public DeleteTicketCommand(Guid id)
        {
            Id = id;
        }
    }
}
