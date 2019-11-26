using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.ViewModels
{
    public class AirportVM
    {
        public string AirportId { get; set; }
        public string AirportName { get; set; }
        public string Address { get; set; }
        public AirportVM()
        {
        }
        public AirportVM(string id, string name, string Address)
        {
            this.AirportId = id;
            this.AirportName = name;
            this.Address = Address;
        }
        public AirportVM(AirportDTO Airport)
        {
            this.AirportId = Airport.AirportId;
            this.AirportName = Airport.AirportName;
            this.Address = Airport.Address.toString();
        }
        public AirportVM(Airport Airport)
        {
            this.AirportId = Airport.AirportId;
            this.AirportName = Airport.AirportName;
            this.Address = Airport.Address.toString();
        }
    }
}