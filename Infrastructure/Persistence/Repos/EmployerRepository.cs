using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections;
namespace Infrastructure.Persistence.Repos
{
    public class EmployerRepository : Repository<Employer>, IEmployerRepository
    {
        protected new GreenairContext Context => base.Context as GreenairContext;
        public EmployerRepository(GreenairContext context) : base(context)
        {
        }

        new public async Task<Employer> GetByAsync(string id)
        {
            try
            {
                var res = await Task.Run(() => this.Context.Employers.AsNoTracking().Where(cus => cus.Id.Equals(id)));
                if (res.Count() != 1) return null;
                else return res.ElementAt(0);

            }
            catch (Exception e)
            {
                Console.WriteLine("GetByEmployerAsync() Unexpected: " + e);
                return null;
            }
        }
    }
}