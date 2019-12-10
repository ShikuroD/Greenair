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
        public string CheckType { get; set; }
        public IEnumerable<FlightDTO> ListFlights_1 { get; set; }
        public IEnumerable<FlightDTO> ListFlights_2 { get; set; }
        private readonly ILogger<FlightModel> _logger;

        public FlightModel(ILogger<FlightModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            
            var FlightSearch = SessionHelper.GetObjectFromJson<Dictionary<string,object>>(HttpContext.Session,"FlightSearch");
            if(FlightSearch != null)
            {
                ViewData["from_city"] = FlightSearch["from_city"];
                ViewData["where_city"] = FlightSearch["where_city"];
                ViewData["from"] = FlightSearch["from"];
                ViewData["where"] = FlightSearch["where"];
                string type = FlightSearch["type"].ToString();
                string vlDepDate = FlightSearch["depdate"].ToString();
                string vlArrDate = FlightSearch["arrdate"].ToString();
                DateTime depDate = DateTime.ParseExact(vlDepDate, "dd/MM/yyyy", null); 
                DateTime arrDate = DateTime.ParseExact(vlArrDate, "dd/MM/yyyy", null);
                ViewData["depDate"] = depDate.ToString("dddd, dd MMMM yyyy");
                ViewData["arrDate"] = arrDate.ToString("dddd, dd MMMM yyyy");
                ViewData["value_dep_date"] = depDate.ToString("dddd-dd/MM/yyyy");
                ViewData["value_arr_date"] = arrDate.ToString("dddd-dd/MM/yyyy");

                Msg = depDate.ToString("dddd dd MMMM yyyy");
                int Adults = Convert.ToInt32(FlightSearch["adults"]);
                int Childs = Convert.ToInt32(FlightSearch["childs"]);
                ViewData["text"] = Adults;
                // DateTime arrDate = DateTime.;
                if(type == "round"){
                    // if( await _flightService.searchFlightAsync(FlightSearch["from"].ToString(),FlightSearch["where"].ToString(),depDate,Adults,Childs) == null)
                    // {
                    //     Msg = "Cant found anything!";
                    // }
                    // else{

                    // }
                    ListFlights_1 = await _flightService.searchFlightAsync(FlightSearch["from"].ToString(),FlightSearch["where"].ToString(),depDate,Adults,Childs);
                    ListFlights_2 = await _flightService.searchFlightAsync(FlightSearch["where"].ToString(),FlightSearch["from"].ToString(),arrDate,Adults,Childs);
                    CheckType = "round";
                }
                else{
                    ListFlights_1 = await _flightService.searchFlightAsync(FlightSearch["from"].ToString(),FlightSearch["where"].ToString(),depDate,Adults,Childs);
                    CheckType = "one";
                }

                
            }
        }
        
    }
    // private class Account
    // {
    //     public string Username { get; set; }
    //     public string Password { get; set; }
    // }
}
