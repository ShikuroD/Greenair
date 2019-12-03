using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Presentation.Helpers;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Http;
using ApplicationCore.Interfaces;

namespace Presentation.Pages
{
    public class IndexModel : PageModel
    {
        //private readonly ILogger<IndexModel> _logger;
        private readonly IUnitOfWork _unitofwork;

        public IndexModel(IUnitOfWork unitofwork)
        {
            this._unitofwork = unitofwork;
        }
        [BindProperty]
        public string From { get; set; }
        [BindProperty]
        public string Where { get; set; }
        [BindProperty]
        public string DepDate { get; set; }
        [BindProperty]
        public string ArrDate { get; set; }
        [BindProperty]
        public string NumAdults { get; set; }
        [BindProperty]
        public string NumChilds { get; set; }
        [BindProperty]
        public string FlightType { get; set; }
        public IEnumerable<Airport> ListAirports { get; set; }
        //public List<FlightDetail> FlightSearch { get; set; }
        public string Msg { get; set; }
        // public IndexModel(ILogger<IndexModel> logger)
        // {
        //     _logger = logger;
        // }

        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            var FlightSearch = new Dictionary<string,object>();
            FlightSearch.Add("from",From);
            FlightSearch.Add("where",Where);
            FlightSearch.Add("depdate",DepDate);
            FlightSearch.Add("arrdate",ArrDate);
            FlightSearch.Add("type",FlightType);
            FlightSearch.Add("adults",NumAdults);
            FlightSearch.Add("childs",NumChilds);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "FlightSearch", FlightSearch);
            return RedirectToPage("Flight");
        }
        public IActionResult OnGetAirPort(string term)
        {
            ListAirports =  _unitofwork.Airports.GetAll();
            var ListAirportNames = from m in ListAirports
                                where m.AirportName.Contains(term)
                                select m.AirportName
                                ;
            return new JsonResult(ListAirportNames);
        }
    }
}