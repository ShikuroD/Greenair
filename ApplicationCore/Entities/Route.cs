using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;
namespace ApplicationCore.Entities
{
    public class Route : IAggregateRoot
    {

        public string RouteId { get; set; }

        public string Origin { get; set; }
        public Airport OrgAirport { get; set; }

        public string Destination { get; set; }
        public Airport DesAirport { get; set; }

        public FlightTime FlightTime { get; set; }
        public IList<FlightDetail> FlightDetails { get; set; }
    }
}