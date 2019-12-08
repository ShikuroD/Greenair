using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;
using ApplicationCore;

namespace ApplicationCore.Entities
{
    public class Airport : IAggregateRoot
    {
        public string AirportId { get; set; }

        public string AirportName { get; set; }

        public Address Address { get; set; }

        public STATUS Status { get; set; }

        public IList<Route> RouteStarts { get; set; }

        public IList<Route> RouteEnds { get; set; }

        public Airport() { }

        public Airport(string AirportId, string AirportName, Address address)
        {
            this.AirportId = AirportId;
            this.AirportName = AirportName;
            this.Address = address;
        }

        public Airport(Airport airport)
        {
            this.AirportId = airport.AirportId;
            this.AirportName = airport.AirportName;
            this.Address = airport.Address;
        }
    }


}