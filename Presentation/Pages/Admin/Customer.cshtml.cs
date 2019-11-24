using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ApplicationCore.Entities;
using Presentation.ViewModels;
// using Presentation.Services.ServiceInterfaces;
using Infrastructure.Persistence;
using ApplicationCore.Interfaces;
namespace Presentation.Pages.Admin
{
    public class CustomerModel : PageModel
    {
        // private readonly ICustomerVMService _service;
        private readonly IUnitOfWork _unitofwork;

        public CustomerModel(IUnitOfWork unitofwork)
        {
            this._unitofwork = unitofwork;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IEnumerable<Customer> ListCustomer { get; set; }

        public async Task OnGet()
        {
            ListCustomer = await _unitofwork.Customers.GetAllAsync();
        }
    }
}