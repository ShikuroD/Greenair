using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using ApplicationCore;

namespace Infrastructure.Persistence.Repos
{
    public class MakerRepository : Repository<Maker>, IMakerRepository
    {
        protected new GreenairContext Context => base.Context as GreenairContext;
        public MakerRepository(GreenairContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Maker>> getMakerByName(string name)
        {
            var predicate = PredicateBuilder.True<Maker>();
            predicate.And(m => m.MakerName.Contains(name));
            return await this.FindAsync(predicate);
        }
    }
}