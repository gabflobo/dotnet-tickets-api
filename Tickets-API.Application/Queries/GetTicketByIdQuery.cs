﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tickets_API.Domain.Entities;

namespace Tickets_API.Application.Queries
{
    public class GetTicketByIdQuery : IRequest<Ticket>
    {
        public Guid Id { get; set; }

        public GetTicketByIdQuery(Guid id)
        {
            Id = id;
        }
    }
}
