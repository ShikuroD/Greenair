using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.EntityFrameworkCore;
using ApplicationCore;
using System;
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
            var predicate = PredicateBuilder.True<Airport>();
            if (!String.IsNullOrEmpty(airport_name)) predicate.And(m => m.AirportName.Contains(airport_name, StringComparison.OrdinalIgnoreCase));
            if (!String.IsNullOrEmpty(city)) predicate.And(m => m.Address.City.Contains(city, StringComparison.OrdinalIgnoreCase));
            if (!String.IsNullOrEmpty(country)) predicate.And(m => m.Address.Country.Contains(country, StringComparison.OrdinalIgnoreCase));
            return await this.FindAsync(predicate);

        }
        public async Task<bool> isDomestic(string airport_id)
        {
            var airport = await this.GetByAsync(airport_id);
            return airport.Address.isDomestic();
        }
    }
}