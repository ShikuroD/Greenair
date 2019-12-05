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
namespace Presentation.Pages.Admin
{
    public class AccountModel : PageModel
    {
        private readonly ILogger<AccountModel> _logger;

        public AccountModel(ILogger<AccountModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public IActionResult OnGetUser()
        {
            string check = "";
            string name = "";
            if(HttpContext.Session.GetString("username") == null)
            {
                check = "null";
            }
            else
            {
                name = HttpContext.Session.GetString("username");
                check = "not";
            }
            Dictionary<string,string> Results = new Dictionary<string,string>();
            Results.Add("name",name);
            Results.Add("check",check);
            return new JsonResult(Results);
        }
    }
}