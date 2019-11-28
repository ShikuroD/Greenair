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
        private readonly IUnitOfWork _unitofwork;
        public STATUS Status { get; set; }

        public CustomerModel(ICustomerService service, IUnitOfWork unitofwork)
        {
            this.Status = STATUS.AVAILABLE;
            this._service = service;
            this._unitofwork = unitofwork;
        }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public IEnumerable<CustomerDTO> ListCustomer { get; set; }

        public async Task OnGet()
        {
            ListCustomer = await _service.getAllCustomerAsync();
        }

        public async Task<IActionResult> OnGetDetailCustomer(string id)
        {
            // var Customer = await _service.getCustomerAsync(id);
            var Customer = await _unitofwork.Customers.GetByAsync(id);
            CustomerVM customerVM = new CustomerVM(Customer);
            // return Content(JsonConvert.SerializeObject(customerVM));
            return new JsonResult(customerVM);
            // return new JsonResult("Abc");
        }

        public async Task<IActionResult> OnGetEditCustomer(string id)
        {
            var Customer = await _unitofwork.Customers.GetByAsync(id);
            CustomerVM customerVM = new CustomerVM(Customer);
            // return Content(JsonConvert.SerializeObject(customerVM));
            return new JsonResult(customerVM);
        }
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
    class CustomerVM
    {
        public string Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Birthdate { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public Account Account { get; set; }
        public string Email { get; set; }
        public STATUS Status { get; set; }
        public CustomerVM() { }

        public CustomerVM(string id, string lastname, string firstname, string birthdate, string phone,
        string address, string email, STATUS sttus)
        {
            this.Id = id; this.LastName = lastname; this.FirstName = firstname; this.Birthdate = birthdate;
            this.Phone = phone; this.Email = email; this.Address = address;
            this.Status = sttus;
        }
        public CustomerVM(CustomerDTO cus)
        {
            this.Id = cus.Id;
            this.LastName = cus.LastName;
            this.FirstName = cus.FirstName;
            this.Birthdate = cus.Birthdate.ToString();
            this.Phone = cus.Phone; this.Email = cus.Email; this.Address = cus.Address.toString();
            this.Status = cus.Status;
            this.Account.Username = cus.Account.Username;
            this.Account.Password = cus.Account.Password;
        }
        public CustomerVM(Customer cus)
        {
            this.Id = cus.Id;
            this.LastName = cus.LastName;
            this.FirstName = cus.FirstName;
            this.Birthdate = cus.BirthDate.ToString();
            this.Phone = cus.Phone; this.Email = cus.Email; this.Address = cus.Address.toString();
            this.Status = cus.Status;
            this.Account.Username = cus.Account.Username;
            this.Account.Password = cus.Account.Password;
        }

    }
}