using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using ApplicationCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repos
{
    public class PlaneRepository : Repository<Plane>, IPlaneRepository
    {
        protected new GreenairContext Context => base.Context as GreenairContext;
        public PlaneRepository(GreenairContext context) : base(context)
        {
        }
        public async Task<IEnumerable<Plane>> getPlanebyMakerId(string maker_id)
        {
            var predicate = PredicateBuilder.True<Plane>();
            predicate.And(m => m.MakerId.Equals(maker_id));
            return await this.FindAsync(predicate);
        }
    }
}