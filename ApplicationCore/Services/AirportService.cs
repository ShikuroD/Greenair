using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using AutoMapper;
using System;
namespace ApplicationCore.Services
{
    public class AirportService : Service<Airport, AirportDTO, AirportDTO>, IAirportService
    {
        public IEnumerable<Airport> List { get; set; }
        public AirportService(IUnitOfWork _unitOfWork, IMapper _mapper) : base(_unitOfWork, _mapper)
        {
            List = unitOfWork.Airports.GetAllAsync().GetAwaiter().GetResult();
        }
        //query
        public async Task<AirportDTO> getAirportAsync(string airport_id)
        {
            return this.toDto(await unitOfWork.Airports.GetByAsync(airport_id));
        }
        public async Task<IEnumerable<Object>> searchAirport(string term)
        {
            var airports = await this.getAllAirportAsync();
            var res = airports.Where(t =>
                                t.AirportName.ToLower().StartsWith(term.ToLower())).Select(t => new { Name = t.AirportName, Id = t.AirportId }
                                ).ToList();
            return res;
        }
        public async Task<IEnumerable<Object>> getAirportName()
        {
            var airports = await this.getAllAirportAsync();
            var res = airports.Select(t => new { Name = t.AirportName, Id = t.AirportId }
                                ).ToList();
            return res;
        }
        public async Task<IEnumerable<AirportDTO>> getAllAirportAsync()
        {
            return this.toDtoRange(await unitOfWork.Airports.GetAllAsync());
        }
        public async Task<IEnumerable<AirportDTO>> getAirportByConditionsAsync(string airport_name, string city, string country)
        {
            return this.toDtoRange(await unitOfWork.Airports.getAirportByConditions(airport_name, city, country));
        }
        public async Task<bool> isDomestic(string airport_id)
        {
            return await unitOfWork.Airports.isDomestic(airport_id);
        }




        //actions
        public async Task addAirportAsync(AirportDTO dto)
        {
            if (await unitOfWork.Airports.GetByAsync(dto.AirportId) == null)
            {
                var airport = this.toEntity(dto);
                await unitOfWork.Airports.AddAsync(airport);
                await unitOfWork.CompleteAsync();
            }
        }
        public async Task removeAirportAsync(string airport_id)
        {
            var airport = await unitOfWork.Airports.GetByAsync(airport_id);
            if (airport != null)
            {
                await unitOfWork.Airports.RemoveAsync(airport);
                await unitOfWork.CompleteAsync();
            }
        }
        public async Task updateAirportAsync(AirportDTO dto)
        {
            if (await unitOfWork.Airports.GetByAsync(dto.AirportId) != null)
            {
                var airport = this.toEntity(dto);
                await unitOfWork.Airports.UpdateAsync(airport);
            }
            else
            {
                var airport = this.toEntity(dto);
                await unitOfWork.Airports.AddAsync(airport);
            }
            await unitOfWork.CompleteAsync();
        }
    }
}