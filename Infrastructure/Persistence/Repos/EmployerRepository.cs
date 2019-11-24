using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Collections.Generic;
using ApplicationCore;
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
                var res = await Task.Run(() => this.Context.Employers.AsNoTracking().Where(emp => emp.Id.Equals(id)));
                if (res.Count() != 1) return null;
                else return res.ElementAt(0);

            }
            catch (Exception e)
            {
                Console.WriteLine("GetByEmployerAsync() Unexpected: " + e);
                return null;
            }
        }
        public async Task<IEnumerable<Employer>> getEmployerByName(string lastname, string firstname)
        {
            var predicate = PredicateBuilder.True<Employer>();
            if (!String.IsNullOrEmpty(lastname)) predicate.And(m => m.LastName.Contains(lastname));
            if (!String.IsNullOrEmpty(firstname)) predicate.And(m => m.FirstName.Contains(firstname));
            return await this.FindAsync(predicate);
        }

        private async Task changeEmployerStatus(string emp_id, STATUS status)
        {
            try
            {
                var emp = await this.GetByAsync(emp_id);
                emp.Status = status;
                this.Context.Update(emp);
                await this.Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("ChangeEmployerStatus() Unexpected: " + e);
            }
        }
        private async Task changeEmployerStatus(Employer emp, STATUS status)
        {
            try
            {
                emp.Status = status;
                this.Context.Update(emp);
                await this.Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("ChangeEmployerStatus() Unexpected: " + e);
            }
        }

        public async Task activate(string emp_id)
        {
            await this.changeEmployerStatus(emp_id, STATUS.AVAILABLE);
        }

        public async Task disable(string emp_id)
        {
            await this.changeEmployerStatus(emp_id, STATUS.DISABLED);
        }

        public async Task activate(Employer emp)
        {
            await this.changeEmployerStatus(emp, STATUS.AVAILABLE);
        }

        public async Task disable(Employer emp)
        {
            await this.changeEmployerStatus(emp, STATUS.DISABLED);
        }
    }
}