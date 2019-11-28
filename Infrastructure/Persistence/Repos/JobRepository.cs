using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using ApplicationCore;
using System.Collections.Generic;
namespace Infrastructure.Persistence.Repos
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        protected new GreenairContext Context => base.Context as GreenairContext;
        public JobRepository(GreenairContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Job>> getJobByName(string job_name)
        {
            var predicate = PredicateBuilder.True<Job>();
            predicate.And(m => m.JobName.Contains(job_name, StringComparison.OrdinalIgnoreCase));
            return await this.FindAsync(predicate);
        }
    }
}