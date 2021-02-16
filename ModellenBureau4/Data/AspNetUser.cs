using System;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ModellenBureau4.Shared;

namespace ModellenBureau4.Data
{
    public class AspNetUser : IdentityUser
    {

        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime BirthDate { get; set; }
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

        public bool Verified { get; set; }
    }
}
