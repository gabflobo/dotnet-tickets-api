using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tickets_API.Application.Commands
{
    public class UpdateTicketCommand : IRequest
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string NomeSolicitante { get; set; }
        public int Status { get; set; }
    }
}
