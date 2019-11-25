using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using ApplicationCore;
namespace Infrastructure.Persistence.Repos
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        protected new GreenairContext Context => base.Context as GreenairContext;
        public CustomerRepository(GreenairContext context) : base(context)
        {

        }
        new public Customer GetBy(string id)
        {
            try
            {
                // var res = this.GetAll().Where(cus => cus.Id.Equals(id));
                // if (res.Count() != 1) return null;
                // else return res.ElementAt(0);
                var res = this.Context.Customers.AsNoTracking().Where(cus => cus.Id.Equals(id));
                if (res.Count() != 1) return null;
                else return res.ElementAt(0);

            }
            catch (Exception e)
            {
                Console.WriteLine("GetByCustomer() Unexpected: " + e);
                return null;
            }
        }

        // new public IEnumerable<Customer> GetAll()
        // {
        //     try
        //     {
        //         return this.Context.Set<Customer>().AsNoTracking().ToList();
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine("GetAllCustomer() Unexpected: " + e);
        //         return null;
        //     }
        // }
        new public async Task<Customer> GetByAsync(string id)
        {
            try
            {
                var res = await Task.Run(() => this.Context.Customers.AsNoTracking().Where(cus => cus.Id.Equals(id)));
                if (res.Count() != 1) return null;
                else return res.ElementAt(0);

            }
            catch (Exception e)
            {
                Console.WriteLine("GetByCustomerAsync() Unexpected: " + e);
                return null;
            }
        }

        public async Task<IEnumerable<Customer>> getCustomerByName(string lastname, string firstname)
        {
            var predicate = PredicateBuilder.True<Customer>();
            if (!String.IsNullOrEmpty(lastname)) predicate.And(m => m.LastName.Contains(lastname, StringComparison.OrdinalIgnoreCase));
            if (!String.IsNullOrEmpty(firstname)) predicate.And(m => m.FirstName.Contains(firstname, StringComparison.OrdinalIgnoreCase));
            return await this.FindAsync(predicate);
        }
        // new public async Task<IEnumerable<Customer>> GetAllAsync()
        // {
        //     try
        //     {
        //         return await this.Context.Set<Customer>().AsNoTracking().ToListAsync();
        //     }
        //     catch (Exception e)
        //     {
        //         Console.WriteLine("GetAllCustomerAsync() Unexpected: " + e);
        //         return null;
        //     }
        // }
        private async Task changeCustomerStatus(string cus_id, STATUS status)
        {
            try
            {
                var cus = await this.GetByAsync(cus_id);
                cus.Status = status;
                this.Context.Update(cus);
                await this.Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("ChangeCustomerStatus() Unexpected: " + e);
            }
        }
        private async Task changeCustomerStatus(Customer cus, STATUS status)
        {
            try
            {
                cus.Status = status;
                this.Context.Update(cus);
                await this.Context.SaveChangesAsync();
            }
            catch (Exception e)
            {
                Console.WriteLine("ChangeCustomerStatus() Unexpected: " + e);
            }
        }

        public async Task activate(string cus_id)
        {
            await this.changeCustomerStatus(cus_id, STATUS.AVAILABLE);
        }

        public async Task disable(string cus_id)
        {
            await this.changeCustomerStatus(cus_id, STATUS.DISABLED);
        }

        public async Task activate(Customer cus)
        {
            await this.changeCustomerStatus(cus, STATUS.AVAILABLE);
        }

        public async Task disable(Customer cus)
        {
            await this.changeCustomerStatus(cus, STATUS.DISABLED);
        }
    }
}