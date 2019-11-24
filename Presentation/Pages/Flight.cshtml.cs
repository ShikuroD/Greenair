using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;

namespace Presentation.Pages
{
    public class FlightModel : PageModel
    {
        
        public string Msg { get; set; }

        private readonly ILogger<FlightModel> _logger;

        public FlightModel(ILogger<FlightModel> logger)
        {
            _logger = logger;
        }

        public void OnGetUser()
        {
        }
        // public IActionResult OnPostLogIn()
        // {
        //     if (Username.Equals("abc") && Password.Equals("123"))
        //     {
        //         HttpContext.Session.SetString("username", Username);
        //         return RedirectToPage("Welcome");
        //     }
        //     else
        //     {
        //         Msg = "Invalid";
        //         return Page();
        //     }
        // }
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
                    if(requestBody.Length > 0)
                    {
                        var obj = JsonConvert.DeserializeObject<Account>(requestBody);
                        if(obj != null)
                        {
                            username = obj.Username;
                            password = obj.Password;
                            if(username.Equals("abc") && password.Equals("123"))
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
            lstString.Add("username",username);
            lstString.Add("msg",Msg);
            return new JsonResult(lstString);
        }
    }
    public class Account{
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
