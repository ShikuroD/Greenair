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
using ApplicationCore;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IO;
using ApplicationCore.DTOs;
using ApplicationCore.Services;
namespace Presentation.Pages.Admin
{
    public class CustomerModel : PageModel
    {
        // private readonly ICustomerVMService _service;
        private readonly ICustomerService _service;
        public STATUS Status { get; set; }

        public CustomerModel(ICustomerService service)
        {
            this.Status = STATUS.AVAILABLE;
            this._service = service;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IEnumerable<CustomerDTO> ListCustomer { get; set; }

        public async Task OnGet()
        {
            ListCustomer = await _service.getAllCustomerAsync();
        }

        public IActionResult OnGetDetailCustomer(string id)
        {
            var Customer = _service.getCustomerAsync(id);
            // CustomerDTO CustomerVM = new CustomerDTO(Customer);
            // return Content(JsonConvert.SerializeObject(CustomerDTO));
            // return new JsonResult(CustomerVM);
            return new JsonResult("Abc");
        }

        // public IActionResult OnGetEditCustomer(string id)
        // {
        //     // var Customer = _service.Customers.GetBy(id);
        //     // CustomerDTO CustomerVM = new CustomerDTO(Customer);
        //     // return Content(JsonConvert.SerializeObject(CustomerDTO));
        //     // return new JsonResult(CustomerVM);
        //     return new JsonResult("Abc");
        // }
        // public async Task<IActionResult> OnPostEditCustomer()
        // {
        //     string respone = "Successful";
        //     MemoryStream stream = new MemoryStream();
        //     Request.Body.CopyTo(stream);
        //     stream.Position = 0;
        //     using (StreamReader reader = new StreamReader(stream))
        //     {
        //         string requestBody = reader.ReadToEnd();
        //         if (requestBody.Length > 0)
        //         {
        //             var obj = JsonConvert.DeserializeObject<CustomerDTO>(requestBody);
        //             if (obj != null)
        //             {
        //                 // Address address = new Address();
        //                 // address.toValue(obj.Address);
        //                 // Customer Customer = new Customer();
        //                 // Customer.CustomerId = obj.CustomerId;
        //                 // Customer.CustomerName = obj.CustomerName;
        //                 // Customer.Address = address;
        //                 // await _service.Customers.UpdateAsync(Customer);
        //                 // await _service.CompleteAsync();
        //             }
        //         }
        //     }
        //     return new JsonResult(respone);
        // }
        // public async Task<IActionResult> OnPostDeleteCustomer()
        // {
        //     string CustomerId = "";
        //     MemoryStream stream = new MemoryStream();
        //     Request.Body.CopyTo(stream);
        //     stream.Position = 0;
        //     using (StreamReader reader = new StreamReader(stream))
        //     {
        //         string requestBody = reader.ReadToEnd();
        //         if (requestBody.Length > 0)
        //         {
        //             var obj = JsonConvert.DeserializeObject<CustomerDTO>(requestBody);
        //             if (obj != null)
        //             {
        //                 // CustomerId = obj.CustomerId;
        //                 // var item = await _service.Customers.GetByAsync(CustomerId);
        //                 // await _service.Customers.RemoveAsync(item);
        //                 // await _service.CompleteAsync();
        //             }
        //         }
        //     }
        //     string mes = "Remove " + CustomerId + " Success!";
        //     return new JsonResult(mes);
        // }
    }
}