using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repos
{
    public class MakerRepository : Repository<Maker>, IMakerRepository
    {
        protected new GreenairContext Context => base.Context as GreenairContext;
        public MakerRepository(GreenairContext context) : base(context)
        {
        }
    }
}