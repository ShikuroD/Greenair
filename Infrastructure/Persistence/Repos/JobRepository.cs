using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Persistence.Repos
{
    public class JobRepository : Repository<Job>, IJobRepository
    {
        protected new GreenairContext Context => base.Context as GreenairContext;
        public JobRepository(GreenairContext context) : base(context)
        {
        }
    }
}