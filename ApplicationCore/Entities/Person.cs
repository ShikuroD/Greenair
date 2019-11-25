using System.ComponentModel.DataAnnotations;
using ApplicationCore.Interfaces;
using ApplicationCore;
using System;
namespace ApplicationCore.Entities
{
    public class Person : IAggregateRoot
    {
        public Person() { }
        public Person(string id, string lastName, string firstName, DateTime birthDate, string phone, Address address, STATUS status)
        {
            this.Id = id;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.BirthDate = birthDate;
            this.Phone = phone;
            this.Address = address;
            this.Status = status;

        }
        public Person(string id, string lastName, string firstName, DateTime birthDate, string phone, Address address)
        {
            this.Id = id;
            this.LastName = lastName;
            this.FirstName = firstName;
            this.BirthDate = birthDate;
            this.Phone = phone;
            this.Address = address;

        }
        public string Id { get; set; }

        public string LastName { get; set; }

        public string FirstName { get; set; }

        public string FullName
        {
            get
            {
                return LastName + " " + FirstName;
            }
        }

        public DateTime BirthDate { get; set; }

        public string Phone { get; set; }

        public Address Address { get; set; }

        public Account Account { get; set; }

        public STATUS Status { get; set; }


    }

}