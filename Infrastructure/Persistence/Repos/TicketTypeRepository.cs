using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repos
{
    public class TicketTypeRepository : Repository<TicketType>, ITicketTypeRepository
    {
        protected new GreenairContext Context => base.Context as GreenairContext;
        public TicketTypeRepository(GreenairContext context) : base(context)
        {
        }
    }
}