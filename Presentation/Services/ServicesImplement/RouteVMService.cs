using System.Threading.Tasks;
using System.Collections.Generic;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Presentation.ViewModels;
using Presentation.Services.ServiceInterfaces;
using AutoMapper;
using ApplicationCore.Services;
using ApplicationCore;

namespace Presentation.Services.ServicesImplement
{
    public class RouteVMService : IRouteVMService
    {
        private int pageSize = 3;
        private readonly IRouteService _service;
        private readonly IMapper _mapper;

        public RouteVMService(IRouteService service, IMapper mapper)
        {
            _service = service;
            _mapper = mapper;
        }

        public async Task<RoutePageVM> GetRoutePageViewModelAsync(string searchString, int pageIndex = 1)
        {
            // var movies = await _service.GetMoviesAsync(searchString, genre);
            var Routes = await _service.getAllRouteAsync();
            // Routes = await _service.SortAsync();
            if (searchString != null)
            {
                // Routes = await _service.getRouteByConditionsAsync(searchString, "", "");
            }
            // var genres = await _service.GetGenresAsync();
            // var abc = _mapper.Map<IEnumerable<Route>, IEnumerable<RouteDTO>>(Routes);

            return new RoutePageVM
            {
                Routes = PaginatedList<RouteDTO>.Create(Routes, pageIndex, pageSize)
            };
        }

    }
}