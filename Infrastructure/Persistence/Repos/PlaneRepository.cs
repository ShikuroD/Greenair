using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repos
{
    public class PlaneRepository : Repository<Plane>, IPlaneRepository
    {
        protected new GreenairContext Context => base.Context as GreenairContext;
        public PlaneRepository(GreenairContext context) : base(context)
        {
        }
    }
}