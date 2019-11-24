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
//https://github.com/ShikuroD/Greenair
namespace Presentation.Pages.Admin
{
    public class MakerModel : PageModel
    {
        private readonly IUnitOfWork _unitofwork;

        public MakerModel(IUnitOfWork unitofwork)
        {
            this._unitofwork = unitofwork;
        }

        public IEnumerable<Maker> ListMakers { get; set; }
        public IEnumerable<Plane> ListPlanes { get; set; }

        public async Task OnGet()
        {
            ListMakers = await _unitofwork.Makers.GetAllAsync();
            ListPlanes = await _unitofwork.Planes.GetAllAsync();

        }
        // Maker methods
        public IActionResult OnGetEditMaker(string id)
        {
            var maker = _unitofwork.Makers.GetBy(id);
            MakerVM makerVM = new MakerVM(maker);
            return Content(JsonConvert.SerializeObject(makerVM));
            // return new JsonResult(makerVM);
        }
        public async Task<IActionResult> OnPostEditMaker()
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
                    var obj = JsonConvert.DeserializeObject<MakerVM>(requestBody);
                    if (obj != null)
                    {
                        Address address = new Address();
                        address.toValue(obj.Address);
                        Maker maker = new Maker();
                        maker.MakerId = obj.MakerId;
                        maker.MakerName = obj.MakerName;
                        maker.Address = address;
                        await _unitofwork.Makers.UpdateAsync(maker);
                        await _unitofwork.CompleteAsync();
                    }
                }
            }
            return new JsonResult(respone);
        }
        public async Task<IActionResult> OnPostDeleteMaker()
        {
            string MakerId = "";
            MemoryStream stream = new MemoryStream();
            Request.Body.CopyTo(stream);
            stream.Position = 0;
            using (StreamReader reader = new StreamReader(stream))
            {
                string requestBody = reader.ReadToEnd();
                if (requestBody.Length > 0)
                {
                    var obj = JsonConvert.DeserializeObject<MakerVM>(requestBody);
                    if (obj != null)
                    {
                        MakerId = obj.MakerId;
                        var item = await _unitofwork.Makers.GetByAsync(MakerId);
                        await _unitofwork.Makers.RemoveAsync(item);
                        await _unitofwork.CompleteAsync();
                    }
                }
            }
            string mes = "Remove " + MakerId + " Success!";
            return new JsonResult(mes);
        }
        // Plane methods
        public IActionResult OnGetEditPlane(string id)
        {
            var plane = _unitofwork.Planes.GetBy(id);
            PlaneDTO planeDTO = new PlaneDTO();
            planeDTO.PlaneId = plane.PlaneId;
            planeDTO.SeatNum = plane.SeatNum;
            planeDTO.MakerId = plane.MakerId;
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
                        plane.MakerId = obj.MakerId.Substring(0, 3);
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