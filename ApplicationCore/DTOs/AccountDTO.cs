using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ApplicationCore.Interfaces;

namespace ApplicationCore.DTOs
{
    public class AccountDTO
    {
        [StringLength(20, MinimumLength = 6)]
        [Required]
        public string Username { get; set; }

        [StringLength(20, MinimumLength = 6)]
        [Required]
        public string Password { get; set; }

        public STATUS Status { get; set; }

        [Required]
        public string PersonId { get; set; }
        public PersonDTO Person { get; set; }
    }
}