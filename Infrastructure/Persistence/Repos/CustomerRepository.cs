using System.Linq;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;

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
    }
}