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
using Presentation.Services.ServiceInterfaces;

namespace Presentation.Pages.Admin
{
    public class PlaneModel : PageModel
    {
        private readonly IUnitOfWork _unitofwork;
        private readonly IPlaneVMService _services;

        public PlaneModel(IUnitOfWork unitofwork, IPlaneVMService services)
        {
            this._unitofwork = unitofwork;
            this._services = services;
        }

        public IEnumerable<Maker> ListMakers { get; set; }

        public PlanePageVM ListPlanePage { get; set; }

        public async Task OnGet(int pageIndex = 1)
        {
            ListMakers = await _unitofwork.Makers.GetAllAsync();
            ListPlanePage = await _services.GetPlanePageViewModelAsync("", pageIndex);

        }
        // Plane methods
        public IActionResult OnGetEditPlane(string id)
        {
            var plane = _unitofwork.Planes.GetBy(id);
            PlaneDTO planeDTO = new PlaneDTO();
            planeDTO.PlaneId = plane.PlaneId;
            planeDTO.SeatNum = plane.SeatNum;
            planeDTO.PlaneId = plane.PlaneId;
            return Content(JsonConvert.SerializeObject(planeDTO));
            // return new JsonResult(planedto);
        }
        public async Task<IActionResult> OnPostEditPlane()
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
                    var obj = JsonConvert.DeserializeObject<PlaneDTO>(requestBody);
                    if (obj != null)
                    {
                        Plane plane = new Plane();
                        plane.PlaneId = obj.PlaneId;
                        plane.SeatNum = obj.SeatNum;
                        plane.PlaneId = obj.PlaneId.Substring(0, 3);
                        await _unitofwork.Planes.UpdateAsync(plane);
                        await _unitofwork.CompleteAsync();
                    }
                }
            }
            return new JsonResult(respone);
        }
        public async Task<IActionResult> OnPostDeletePlane()
        {
            string PlaneId = "";
            MemoryStream stream = new MemoryStream();
            Request.Body.CopyTo(stream);
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream))
            {
                string requestBody = reader.ReadToEnd();
                if (requestBody.Length > 0)
                {
                    var obj = JsonConvert.DeserializeObject<PlaneDTO>(requestBody);
                    if (obj != null)
                    {
                        PlaneId = obj.PlaneId;
                        var item = await _unitofwork.Planes.GetByAsync(PlaneId);
                        await _unitofwork.Planes.RemoveAsync(item);
                        await _unitofwork.CompleteAsync();
                    }
                }
            }
            string mes = "Remove " + PlaneId + " Success!";
            return new JsonResult(mes);
        }

    }
}