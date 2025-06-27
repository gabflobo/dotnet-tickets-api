using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets_API.Domain.Entities;
using Tickets_API.Domain.Enums;
using Tickets_API.Domain.Interfaces;
using Tickets_API.Infrastructure.Data;

namespace Tickets_API.Infrastructure.Repositories
{
    public class TicketRepository : ITicketRepository
    {
        private readonly AppDbContext _context;

        public TicketRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Ticket ticket)
        {
            _context.Tickets.Add(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var ticket = await _context.Tickets.FindAsync(id);

            if (ticket == null)
            {
                throw new Exception("Chamado não encontrado");
            }

            _context.Tickets.Remove(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> GetAllAsync()
        {
            return await _context.Tickets.ToListAsync();
        }

        public async Task<Ticket> GetByIdAsync(Guid id)
        {
            return await _context.Tickets.FindAsync(id);
        }

        public async Task UpdateAsync(Ticket ticket)
        {
            _context.Tickets.Update(ticket);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Ticket>> GetByStatusAsync(StatusTicket status)
        {
            return await _context.Tickets.Where(t => t.Status == status).ToListAsync();
        } 
    }
}
