using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Presentation.Helpers;

namespace Presentation.Pages
{
    public class PaymentModel : PageModel
    {
        private readonly ILogger<PaymentModel> _logger;

        public PaymentModel(ILogger<PaymentModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
}
