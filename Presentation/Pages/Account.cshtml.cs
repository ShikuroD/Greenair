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

namespace Presentation.Pages
{
    public class AccountModel : PageModel
    {
        private readonly IAccountService _accountService;
        [ActivatorUtilitiesConstructor]
        public AccountModel(IAccountService accountService)
        {
            _accountService = accountService;
        }
        private readonly ILogger<AccountModel> _logger;
        public string Msg { get; set; }
        public AccountModel(ILogger<AccountModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
        public async Task<IActionResult> OnPostLogIn()
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
                            AccountDTO account = new AccountDTO(username,password);
                            if(await _accountService.loginCheckAsync(account))
                            {
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
            lstString.Add("username", username);
            lstString.Add("msg", Msg);
            return new JsonResult(lstString);
        }
    }
}
