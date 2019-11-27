using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using ApplicationCore.Interfaces;
using System;
namespace ApplicationCore.Entities
{
    public class Customer : Person, IAggregateRoot
    {
        public Customer() : base() { }

        public Customer(string id, string lastName, string firstName, DateTime birthDate, string phone, Address address,
                STATUS status, string email) : base(id, lastName, firstName, birthDate, phone, address, status)
        {
            this.Email = email;

        }

        public Customer(string id, string lastName, string firstName, DateTime birthDate, string phone, Address address,
                string email) : base(id, lastName, firstName, birthDate, phone, address)
        {
            this.Email = email;

        }
        public string Email { get; set; }

        public IList<Ticket> Tickets { get; set; }

    }
}