using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using ApplicationCore;
using System;
using System.Linq;
using LinqKit;
namespace Infrastructure.Persistence.Repos
{
    public class AirportRepository : Repository<Airport>, IAirportRepository
    {
        protected new GreenairContext Context => base.Context as GreenairContext;
        public AirportRepository(GreenairContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Airport>> getAirportByConditions(string airport_name, string city, string country)
        {
            var res = await this.GetAllAsync();
            if (!String.IsNullOrEmpty(airport_name)) res.Where(m => m.AirportName.Contains(airport_name, StringComparison.OrdinalIgnoreCase));
            if (!String.IsNullOrEmpty(city)) res.Where(m => m.Address.City.Contains(city, StringComparison.OrdinalIgnoreCase));
            if (!String.IsNullOrEmpty(country)) res.Where(m => m.Address.Country.Contains(country, StringComparison.OrdinalIgnoreCase));
            return res;

        }
        public async Task<bool> isDomestic(string airport_id)
        {
            var airport = await this.GetByAsync(airport_id);
            return airport.Address.isDomestic();
        }
    }
}