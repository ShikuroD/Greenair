using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repos
{
    public class AirportRepository : Repository<Airport>, IAirportRepository
    {
        protected new GreenairContext Context => base.Context as GreenairContext;
        public AirportRepository(GreenairContext context) : base(context)
        {
        }
    }
}