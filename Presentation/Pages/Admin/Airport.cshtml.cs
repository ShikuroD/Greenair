using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using ApplicationCore.Interfaces;
using ApplicationCore.Entities;
using Newtonsoft.Json;
using Presentation.ViewModels;
using Microsoft.AspNetCore.Http;
using System.IO;
using ApplicationCore.DTOs;
using Presentation.Services.ServicesImplement;

namespace Presentation.Pages.Admin
{
    public class AirportModel : PageModel
    {
        private readonly IUnitOfWork _unitofwork;

        public AirportModel(IUnitOfWork unitofwork)
        {
            this._unitofwork = unitofwork;
        }

        public IEnumerable<Airport> ListAirports { get; set; }

        public async Task OnGet()
        {
            ListAirports = await _unitofwork.Airports.GetAllAsync();

        }
        // Airport methods
        public IActionResult OnGetEditAirport(string id)
        {
            var Airport = _unitofwork.Airports.GetBy(id);
            AirportVM AirportVM = new AirportVM(Airport);
            return Content(JsonConvert.SerializeObject(AirportVM));
            // return new JsonResult(AirportVM);
        }
        public async Task<IActionResult> OnPostEditAirport()
        {
            string respone = "Successful";
            MemoryStream stream = new MemoryStream();
            Request.Body.CopyTo(stream);
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream))
            {
                string requestBody = reader.ReadToEnd();
                if (requestBody.Length > 0)
                {
                    var obj = JsonConvert.DeserializeObject<AirportVM>(requestBody);
                    if (obj != null)
                    {
                        Address address = new Address();
                        address.toValue(obj.Address);
                        Airport Airport = new Airport();
                        Airport.AirportId = obj.AirportId;
                        Airport.AirportName = obj.AirportName;
                        Airport.Address = address;
                        await _unitofwork.Airports.UpdateAsync(Airport);
                        await _unitofwork.CompleteAsync();
                    }
                }
            }
            return new JsonResult(respone);
        }
        public async Task<IActionResult> OnPostDeleteAirport()
        {
            string AirportId = "";
            MemoryStream stream = new MemoryStream();
            Request.Body.CopyTo(stream);
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream))
            {
                string requestBody = reader.ReadToEnd();
                if (requestBody.Length > 0)
                {
                    var obj = JsonConvert.DeserializeObject<AirportVM>(requestBody);
                    if (obj != null)
                    {
                        AirportId = obj.AirportId;
                        var item = await _unitofwork.Airports.GetByAsync(AirportId);
                        await _unitofwork.Airports.RemoveAsync(item);
                        await _unitofwork.CompleteAsync();
                    }
                }
            }
            string mes = "Remove " + AirportId + " Success!";
            return new JsonResult(mes);
        }
        public async Task<IActionResult> OnPostCreateAirport()
        {
            string respone = "True";
            MemoryStream stream = new MemoryStream();
            Request.Body.CopyTo(stream);
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream))
            {
                string requestBody = reader.ReadToEnd();
                if (requestBody.Length > 0)
                {
                    var obj = JsonConvert.DeserializeObject<AirportVM>(requestBody);
                    if (obj != null)
                    {
                        var aa = await _unitofwork.Airports.GetByAsync(obj.AirportId);
                        if (aa == null)
                        {
                            Address address = new Address();
                            address.toValue(obj.Address);
                            Airport Airport = new Airport();
                            Airport.AirportId = obj.AirportId;
                            Airport.AirportName = obj.AirportName;
                            Airport.Address = address;
                            await _unitofwork.Airports.AddAsync(Airport);
                            await _unitofwork.CompleteAsync();
                        }
                        else respone = "False";

                    }
                }
            }
            return new JsonResult(respone);
        }

    }

}