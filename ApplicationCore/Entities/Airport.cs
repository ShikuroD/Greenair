using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;

namespace ApplicationCore.Entities
{
    public class Airport : IAggregateRoot
    {
        public string AirportId { get; set; }

        public string AirportName { get; set; }

        public Address Address { get; set; }

        public IList<Route> RouteStarts { get; set; }

        public IList<Route> RouteEnds { get; set; }
    }


}