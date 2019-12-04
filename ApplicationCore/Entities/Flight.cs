using System.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;
namespace ApplicationCore.Entities
{
    public class Flight : IAggregateRoot
    {
        public string FlightId { get; set; }

        public STATUS Status { get; set; }

        public string PlaneId { get; set; }
        public Plane Plane { get; set; }

        public IList<FlightDetail> FlightDetails { get; set; }

        public IList<Ticket> Tickets { get; set; }

        public Flight() { }
        public Flight(string FlightId, string PlaneId, STATUS Status)
        {
            this.FlightId = FlightId;
            this.Status = Status;
            this.PlaneId = PlaneId;
        }
        public Flight(Flight fli)
        {
            this.FlightId = fli.FlightId;
            this.Status = fli.Status;
            this.PlaneId = fli.PlaneId;
        }
    }
}