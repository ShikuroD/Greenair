using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Presentation.Helpers;
using Presentation.ViewModels;
using System.IO;
using ApplicationCore.DTOs;
using Microsoft.Extensions.DependencyInjection;

namespace Presentation.Pages
{

    public class FlightModel : PageModel
    {
        private readonly IFlightService _flightService;
        [ActivatorUtilitiesConstructor]
        public FlightModel(IFlightService flightService)
        {
            _flightService = flightService;
        }
        public string Msg { get; set; }

        public IEnumerable<FlightDTO> ListFlights { get; set; }
        private readonly ILogger<FlightModel> _logger;

        public FlightModel(ILogger<FlightModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            Msg = "a";
            var FlightSearch = SessionHelper.GetObjectFromJson<Dictionary<string,object>>(HttpContext.Session,"FlightSearch");
            if(FlightSearch == null)
            {
                RedirectToPage("Index");
            }
            else{
                string type = FlightSearch["type"].ToString();
                string vlDepDate = FlightSearch["depdate"].ToString();
                DateTime depDate = DateTime.ParseExact(vlDepDate, "dd/MM/yyyy", null); 
                DateTime arrDate = DateTime.ParseExact(vlDepDate, "dd/MM/yyyy", null);
                // DateTime arrDate = DateTime.;
                if(type == "round"){
                    string vlArrDate = FlightSearch["arrdate"].ToString();
                    arrDate = DateTime.ParseExact(vlArrDate, "dd/MM/yyyy", null);
                }

                int Adults = Convert.ToInt32(FlightSearch["adults"]);
                int Childs = Convert.ToInt32(FlightSearch["childs"]);
            }
            
        //     ListFlights = await _flightService.searchFlightAsync(FlightSearch["from"].ToString(),FlightSearch["where"].ToString(),depDate,arrDate,adults,childs);
        //     if(ListFlights.Count() == 0)
        //     {
        //         Msg = "No flights found!";
        // }
        }
        
    }
    // private class Account
    // {
    //     public string Username { get; set; }
    //     public string Password { get; set; }
    // }
}
