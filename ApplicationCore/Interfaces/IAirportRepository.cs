using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
namespace ApplicationCore.Interfaces
{
    public interface IAirportRepository : IRepository<Airport>
    {
        Task<IEnumerable<Airport>> getAirportByConditions(string airport_name, string city, string country);
        Task<bool> isDomestic(string airport_id);
    }
}