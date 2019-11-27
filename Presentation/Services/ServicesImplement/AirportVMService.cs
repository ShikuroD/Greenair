using System.Threading.Tasks;
using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.ViewModels;
using Presentation.Services.ServiceInterfaces;
using AutoMapper;
namespace Presentation.Services.ServicesImplement
{
    public class AirportVMService : IAirportVMService
    {
        private int pageSize = 3;
        private readonly IUnitOfWork _service;
        private readonly IMapper _mapper;

        public AirportVMService(IUnitOfWork movieService, IMapper mapper)
        {
            _service = movieService;
            _mapper = mapper;
        }

        public AirportPageVM GetAirportPageViewModel(string searchString, int pageIndex = 1)
        {
            // var movies = await _service.GetMoviesAsync(searchString, genre);
            var airports = _service.Airports.GetAll();
            // var genres = await _service.GetGenresAsync();
            var abc = _mapper.Map<IEnumerable<Airport>, IEnumerable<AirportDTO>>(airports);

            return new AirportPageVM
            {
                Airports = PaginatedList<AirportDTO>.Create(abc, pageIndex, pageSize)
            };
        }

    }
}