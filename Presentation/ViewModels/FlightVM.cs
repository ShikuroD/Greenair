using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApplicationCore;
using ApplicationCore.DTOs;
using ApplicationCore.Entities;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Presentation.ViewModels
{
    public class FlightVM
    {
        public string FlightId { get; set; }

        public STATUS Status { get; set; }

        [Required]
        public string PlaneId { get; set; }
        public PlaneDTO Plane { get; set; }

        public IList<FlightDetailDTO> FlightDetails { get; set; }

        public IList<TicketDTO> Tickets { get; set; }
        public FlightVM(FlightDTO flight)
        {
            this.FlightId = flight.FlightId;
            this.Plane = flight.Plane;
            this.FlightDetails = flight.FlightDetails;
            this.PlaneId = flight.PlaneId;
            this.Status = flight.Status;
            this.Tickets = flight.Tickets;
        }
    }
}