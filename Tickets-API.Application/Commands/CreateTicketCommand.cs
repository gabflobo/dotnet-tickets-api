using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets_API.Domain.Entities;

namespace Tickets_API.Application.Commands
{
    public class CreateTicketCommand : IRequest<Ticket>
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string NomeSolicitante { get; set; }
    }
}
