using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Presentation.Helpers;
using Microsoft.AspNetCore.Http;

namespace Presentation.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public string From { get; set; }
        [BindProperty]
        public string Where { get; set; }
        [BindProperty]
        public DateTime DepDate { get; set; }
        [BindProperty]
        public DateTime ArrDate { get; set; }
        [BindProperty]
        public string NumAdults { get; set; }
        [BindProperty]
        public string NumChilds { get; set; }
        [BindProperty]
        public string FlightType { get; set; }
        public string Msg { get; set; }
        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            
        }
        public IActionResult OnPost()
        {
            var FlightSearch = new Dictionary<String,object>();
            FlightSearch.Add("type",FlightType);
            FlightSearch.Add("from",From);
            FlightSearch.Add("where",Where);
            FlightSearch.Add("depdate",DepDate);
            FlightSearch.Add("arrdate",ArrDate);
            FlightSearch.Add("adults",NumAdults);
            FlightSearch.Add("childs",NumChilds);
            SessionHelper.SetObjectAsJson(HttpContext.Session, "FlightSearch", FlightSearch);
            return RedirectToPage("Flight");
        }
    }
}