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
        // public async Task OnPostListPlaneBy(string id)
        // {
        //      this.ListPlanes = await _unitofwork.Planes.FindAsync(id);

        // }
    }

}