using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.Entities;
using ApplicationCore.DTOs;
namespace ApplicationCore.Services
{
    public interface IAirportService : IService<Airport, AirportDTO, AirportDTO>
    {
        //query
        Task<AirportDTO> getAirportAsync(string airport_id);
        Task<IEnumerable<AirportDTO>> getAllAirportAsync();
        Task<IEnumerable<AirportDTO>> getAirportByConditionsAsync(string airport_name, string city, string country);
        Task<bool> isDomestic(string airport_id);

        //actions
        Task addAirportAsync(AirportDTO dto);
        Task removeAirportAsync(string airport_id);
        Task updateAirportAsync(AirportDTO dto);
    }
}