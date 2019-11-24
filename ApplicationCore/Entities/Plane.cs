using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;
namespace ApplicationCore.Entities
{
    public class Plane : IAggregateRoot
    {
        public string PlaneId { get; set; }
        public int SeatNum { get; set; }

        public string MakerId { get; set; }
        public Maker Maker { get; set; }

        public IList<Flight> Flights { get; set; }
    }
}