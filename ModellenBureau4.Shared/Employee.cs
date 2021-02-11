using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ModellenBureau4.Shared
{
    public class Employee : Customer
    {
        [Required]
        public int Weight { get; set; }
        [Required]
        public int Height { get; set; }

    }

}
