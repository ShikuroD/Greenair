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

        public Route() { }

        public Route(string RouteId, string Origin, Airport OrgAirport, string Destination, Airport DesAirport, FlightTime flightTime)
        {
            this.RouteId = RouteId;
            this.Origin = Origin;
            this.OrgAirport = OrgAirport;
            this.Destination = Destination;
            this.DesAirport = DesAirport;
            this.FlightTime = flightTime;
        }

        public Route(Route rou)
        {
            this.RouteId = rou.RouteId;
            this.Origin = rou.Origin;
            this.OrgAirport = rou.OrgAirport;
            this.Destination = rou.Destination;
            this.DesAirport = rou.DesAirport;
            this.FlightTime = rou.FlightTime;
        }
    }
}