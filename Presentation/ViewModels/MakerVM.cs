using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.ViewModels
{
    public class MakerVM
    {
        public string MakerId { get; set; }
        public string MakerName { get; set; }
        public string Address { get; set; }
        public MakerVM()
        {
        }
        public MakerVM(string id, string name, string Address)
        {
            this.MakerId = id;
            this.MakerName = name;
            this.Address = Address;
        }
        public MakerVM(MakerDTO maker)
        {
            this.MakerId = maker.MakerId;
            this.MakerName = maker.MakerName;
            this.Address = maker.Address.toString();
        }
        public MakerVM(Maker maker)
        {
            this.MakerId = maker.MakerId;
            this.MakerName = maker.MakerName;
            this.Address = maker.Address.toString();
        }
    }
}