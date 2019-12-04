using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ApplicationCore.Interfaces;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Services;
namespace Presentation.Pages.Admin
{
    public class FlightModel : PageModel
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IFlightService _services;

        public FlightModel(IFlightService services, IUnitOfWork unitofwork)
        {
            _unitofwork = unitofwork;
            _services = services;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IEnumerable<FlightDTO> ListFlights { get; set; }
        public IEnumerable<Plane> ListPlanes { get; set; }
        public IEnumerable<Route> ListRoutes { get; set; }
        public IEnumerable<Airport> ListAirports { get; set; }
        public IEnumerable<FlightDetail> FlightDetail { get; set; }
        public async Task OnGet()
        {
            ListFlights = await _services.getAllFlightAsync();
            ListPlanes = await _unitofwork.Planes.GetAllAsync();
            ListRoutes = await _unitofwork.Routes.GetAllAsync();
            ListAirports = await _unitofwork.Airports.GetAllAsync();
        }
    }
}