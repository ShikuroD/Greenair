using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;
namespace ApplicationCore.Entities
{
    public class Account : IAggregateRoot
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public STATUS Status { get; set; }

        public string PersonId { get; set; }
        public Person Person { get; set; }
    }
}