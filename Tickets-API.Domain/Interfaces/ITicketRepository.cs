using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets_API.Domain.Entities;
using Tickets_API.Domain.Enums;

namespace Tickets_API.Domain.Interfaces
{
    public interface ITicketRepository
    {
        Task<Ticket> GetByIdAsync(Guid id);
        Task<IEnumerable<Ticket>> GetAllAsync();
        Task AddAsync(Ticket ticket);
        Task UpdateAsync(Ticket ticket);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Ticket>> GetByStatusAsync(StatusTicket status);
    }
}
