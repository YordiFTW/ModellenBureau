using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModellenBureau4.Shared
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Street { get; set; }
        [Required]
        public string Zip { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public Gender Gender { get; set; }
        [Required]
        public int Weight { get; set; }
        [Required]
        public int Height { get; set; }
        [Required]
        public string ImageUrl { get; set; }

        public bool Verified { get; set; }

        public string PhotoPath { get; set; }

    }

}
