using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using ApplicationCore;
using System;
using LinqKit;
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
            var predicate = PredicateBuilder.New<Maker>();
            predicate = predicate.And(m => m.MakerName.Contains(name, StringComparison.OrdinalIgnoreCase));
            return await this.FindAsync(predicate);
        }
    }
}