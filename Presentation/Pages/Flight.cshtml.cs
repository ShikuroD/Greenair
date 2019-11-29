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
            //     var FlightSearch = SessionHelper.GetObjectFromJson<Dictionary<string,object>>(HttpContext.Session,"FlightSearch");
            //     string type = FlightSearch["type"].ToString();
            //     string vlDepDate = FlightSearch["depdate"].ToString();
            //     DateTime depDate = DateTime.ParseExact(vlDepDate, "dd/MM/yyyy", null); 
            //     DateTime arrDate = DateTime.ParseExact(vlDepDate, "dd/MM/yyyy", null);
            //     // DateTime arrDate = DateTime.;
            //     if(type == "round"){
            //         string vlArrDate = FlightSearch["arrdate"].ToString();
            //         arrDate = DateTime.ParseExact(vlArrDate, "dd/MM/yyyy", null);
            //     }

            //     string vlAdults = FlightSearch["adults"].ToString();
            //     var adults = Convert.ToInt32(vlAdults);
            //     string vlChilds = FlightSearch["childs"].ToString();
            //     var childs = Convert.ToInt32(vlChilds);
            //     ListFlights = await _flightService.searchFlightAsync(FlightSearch["from"].ToString(),FlightSearch["where"].ToString(),depDate,arrDate,adults,childs);
            //     if(ListFlights.Count() == 0)
            //     {
            //         Msg = "No flights found!";
            // }
        }
        public IActionResult OnPostLogIn()
        {
            string username = "";
            string password = "";
            {
                MemoryStream stream = new MemoryStream();
                Request.Body.CopyTo(stream);
                stream.Position = 0;
                using (StreamReader reader = new StreamReader(stream))
                {
                    string requestBody = reader.ReadToEnd();
                    if (requestBody.Length > 0)
                    {
                        var obj = JsonConvert.DeserializeObject<Account>(requestBody);
                        if (obj != null)
                        {
                            username = obj.Username;
                            password = obj.Password;
                            if (username.Equals("abc") && password.Equals("123"))
                            {
                                HttpContext.Session.SetString("username", username);
                                Msg = "true";
                            }
                            else
                            {
                                Msg = "false";
                            }
                        }
                    }
                }
            }
            Dictionary<string, string> lstString = new Dictionary<string, string>();
            lstString.Add("username", username);
            lstString.Add("msg", Msg);
            return new JsonResult(lstString);
        }
    }
    // private class Account
    // {
    //     public string Username { get; set; }
    //     public string Password { get; set; }
    // }
}
