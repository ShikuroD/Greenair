using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;
namespace ApplicationCore.Entities
{
    public class TicketType : IAggregateRoot
    {
        public string TicketTypeId { get; set; }

        public string TicketTypeName { get; set; }

        public decimal BasePrice { get; set; }

        public IList<Ticket> Tickets { get; set; }
    }
}