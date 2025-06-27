using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets_API.Domain.Enums;

namespace Tickets_API.Domain.Entities
{
    public class Ticket : BaseEntity
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string NomeSolicitante { get; set; }
        public StatusTicket Status { get; set; } = StatusTicket.Aberto;
    }
}
