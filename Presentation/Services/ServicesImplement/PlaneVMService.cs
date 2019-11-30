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
    public class PlaneVMService : IPlaneVMService
    {
        private int pageSize = 3;
        private readonly IUnitOfWork _service;
        private readonly IMapper _mapper;

        public PlaneVMService(IUnitOfWork movieService, IMapper mapper)
        {
            _service = movieService;
            _mapper = mapper;
        }

        public async Task<PlanePageVM> GetPlanePageViewModelAsync(string searchString, int pageIndex = 1)
        {
            // var movies = await _service.GetMoviesAsync(searchString, genre);
            var Planes = await _service.Planes.GetAllAsync();
            // if (searchString != null)
            // {
            //     Planes = await _service.Planes.getPlanebyMakerId(searchString);
            // }
            // var genres = await _service.GetGenresAsync();
            var abc = _mapper.Map<IEnumerable<Plane>, IEnumerable<PlaneDTO>>(Planes);

            return new PlanePageVM
            {
                Planes = PaginatedList<PlaneDTO>.Create(abc, pageIndex, pageSize)
            };
        }

    }
}