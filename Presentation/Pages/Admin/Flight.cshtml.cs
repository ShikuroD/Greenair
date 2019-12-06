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
using Newtonsoft.Json;
using System.IO;

namespace Presentation.Pages.Admin
{
    public class FlightModel : PageModel
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IFlightService _services;
        private readonly IPlaneService _servicesPlane;

        public FlightModel(IFlightService services, IUnitOfWork unitofwork,IPlaneService servicesPlane)
        {
            _unitofwork = unitofwork;
            _services = services;
            _servicesPlane=servicesPlane;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IEnumerable<FlightDTO> ListFlights { get; set; }
        public IList<string> ListNamePlanes { get; set; }
        public IEnumerable<Route> ListRoutes { get; set; }
        public IEnumerable<Airport> ListAirports { get; set; }
        public IEnumerable<FlightDetail> ListFlightDetail { get; set; }
        public IList<FlightDetailVM> ListFlightDetailVM { get; set; }
        public async Task OnGet()
        {   
            ListNamePlanes =new List<string>();
            ListFlights = await _services.getAllFlightAsync();
            var ListPlanes = await _servicesPlane.getAllPlaneAsync();
            foreach( var item in ListPlanes){
                var s=await _servicesPlane.getPlaneFullname(item.PlaneId);
                ListNamePlanes.Add(s);
            }

            ListRoutes = await _unitofwork.Routes.GetAllAsync();
            ListAirports = await _unitofwork.Airports.GetAllAsync();
        }
        public async Task<JsonResult> OnGetDetailFlight(string id)
        {
            var Flight = await _services.getFlightAsync(id);
            var ListFlightDetailId = await _services.getAllFlightDetailAsync(Flight.FlightId);
            ListFlightDetailVM = new List<FlightDetailVM>();
            foreach (var item in ListFlightDetailId)
            {
                var route = await _unitofwork.Routes.GetByAsync(item.RouteId);
                var origin = await _unitofwork.Airports.GetByAsync(route.Origin);
                var destination = await _unitofwork.Airports.GetByAsync(route.Destination);
                ListFlightDetailVM.Add(new FlightDetailVM(item, origin, destination));
            }
            Dictionary<string, object> Result = new Dictionary<string, object>();
            Result.Add("flight", Flight);
            Result.Add("listFlight", ListFlightDetailVM);
            return new JsonResult(Result);
        }
        public async Task<IActionResult> OnPostDeleteFlight()
        {
            string FlightId = "";
            MemoryStream stream = new MemoryStream();
            Request.Body.CopyTo(stream);
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream))
            {
                string requestBody = reader.ReadToEnd();
                if (requestBody.Length > 0)
                {
                    var obj = JsonConvert.DeserializeObject<FlightDTO>(requestBody);
                    if (obj != null)
                    {
                        FlightId = obj.FlightId;
                        await _services.removeFlightAsync(FlightId);
                    }
                }
            }
            string mes = "Remove flight" + FlightId + " Success!";
            return new JsonResult(mes);
        }
    }
    public class FlightDetailVM
    {
        public string FlightId { get; set; }
        public string FlightDetailId { get; set; }
        public string RouteId { get; set; }
        public string OriginAirport { get; set; }
        public string OriginCountry { get; set; }
        public string DesAirport { get; set; }
        public string DesCountry { get; set; }
        public string ArrDate { get; set; }
        public string DepDate { get; set; }
        public FlightDetailVM() { }
        public FlightDetailVM(
            string FlightId, string FlightDetailId, string RouteId,
            string OriginAirport, string OriginCountry,
            string DesAirport, string DesCountry,
            string ArrDate, string DepDate
            )
        {
            this.FlightId = FlightId;
            this.FlightDetailId = FlightDetailId;
            this.RouteId = RouteId;
            this.OriginAirport = OriginAirport;
            this.OriginCountry = OriginCountry;
            this.DesAirport = DesAirport;
            this.DesCountry = DesCountry;
            this.ArrDate = ArrDate;
            this.DepDate = DepDate;
        }
        public FlightDetailVM(FlightDetail fd, Airport Origin, Airport Destination)
        {
            this.FlightId = fd.FlightId;
            this.FlightDetailId = fd.FlightDetailId;
            this.RouteId = fd.RouteId;
            this.OriginAirport = Origin.AirportName;
            this.OriginCountry = Origin.Address.Country;
            this.DesAirport = Destination.AirportName;
            this.DesCountry = Destination.Address.Country;
            this.ArrDate = fd.ArrDate.ToString();
            this.DepDate = fd.DepDate.ToString();
        }
        public FlightDetailVM(FlightDetailDTO fd, Airport Origin, Airport Destination)
        {
            this.FlightId = fd.FlightId;
            this.FlightDetailId = fd.FlightDetailId;
            this.RouteId = fd.RouteId;
            this.OriginAirport = Origin.AirportName;
            this.OriginCountry = Origin.Address.Country;
            this.DesAirport = Destination.AirportName;
            this.DesCountry = Destination.Address.Country;
            this.ArrDate = fd.ArrDate.ToString();
            this.DepDate = fd.DepDate.ToString();
        }
        public FlightDetailVM(FlightDetailDTO fd, AirportDTO Origin, AirportDTO Destination)
        {
            this.FlightId = fd.FlightId;
            this.FlightDetailId = fd.FlightDetailId;
            this.RouteId = fd.RouteId;
            this.OriginAirport = Origin.AirportName;
            this.OriginCountry = Origin.Address.Country;
            this.DesAirport = Destination.AirportName;
            this.DesCountry = Destination.Address.Country;
            this.ArrDate = fd.ArrDate.ToString();
            this.DepDate = fd.DepDate.ToString();
        }
    }
}