using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
namespace Presentation.Pages.Admin
{
    public class EmployerModel : PageModel
    {
        private readonly ILogger<EmployerModel> _logger;

        public EmployerModel(ILogger<EmployerModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}