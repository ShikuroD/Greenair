using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using ApplicationCore.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Presentation.Helpers;
using Presentation.Services.ServiceInterfaces;

namespace Presentation.Pages
{
    public class AccountModel : PageModel
    {
        private readonly IAccountService _accountService;
        [ActivatorUtilitiesConstructor]
        private readonly ICustomerService _customerService;
        public AccountModel(IAccountService accountService, ICustomerService customerService)
        {
            _accountService = accountService;
            _customerService = customerService;
        }
        // private readonly ILogger<AccountModel> _logger;
        public string Msg { get; set; }
        // public AccountModel(ILogger<AccountModel> logger)
        // {
        //     _logger = logger;
        // }

        public IActionResult OnGetUserField()
        {
            
            string userId = "";
            string check = "";
            if( HttpContext.Session.GetString("username") != null)
            {                
                // html+="<div class='dropdown user nav-link'>";
                // html+="<a id='account-dropdown' class=' dropdown-toggle ' style='cursor:pointer' type='button' data-toggle='dropdown' aria-haspopup='true' aria-expanded='false' >";
                // html+="<span class='ion-ios-person' ></span>";
                // html+="<span style='padding-left:10px'>"+ userId +"</span>";
                // html+="</a>";
                // html+="<div class='dropdown-menu' aria-labelledby='account-dropdown'>";
                
                // html+="<button class='dropdown-item' type='button'>Your Profile</button>";
                // html+="<button id='logOut' class='dropdown-item'  type='button'>Logout</button>";
                // html+="</div>";
                // html+="</div>";
                check = "not"; 
                userId = HttpContext.Session.GetString("username");

            }
            else{   
                // html+="<span class='ion-ios-person' ></span>";
                // html+="<span style='padding-left:10px'>Log in</span>";
                check = "null";
            }
            Dictionary<string,string> Results = new Dictionary<string, string>();
            Results.Add("userid",userId);
            Results.Add("check",check);
            return new JsonResult(Results);
        }
        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostLogIn()
        {
            string username = "";
            string password = "";
            string userId = "";
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
                            AccountDTO account = new AccountDTO(username,password);
                            if(await _accountService.loginCheckAsync(account))
                            {
                                
                                Person Person = await _accountService.getPersonByAccount(username);
                                CustomerDTO customer = await _customerService.getCustomerAsync(Person.Id.ToString());
                                userId = customer.FirstName;
                                HttpContext.Session.SetString("username",userId);
                                Msg = "true";
                            }
                            else{
                                Msg="False";   
                            }
                        }
                    }
                }
            }
            Dictionary<string, string> lstString = new Dictionary<string, string>();
            lstString.Add("userid", userId);
            lstString.Add("msg", Msg);
            return new JsonResult(lstString);
        }
        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Remove("username");
            return new JsonResult(Msg);
        }

    }
}
