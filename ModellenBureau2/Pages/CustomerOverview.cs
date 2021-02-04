using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModellenBureau2.Shared;

namespace ModellenBureau2.Pages
{
    public partial class CustomerOverview
    {

        public IEnumerable<Customer> Customers { get; set; }
        public List<Country> Countries { get; set; }

        protected override Task OnInitializedAsync()
        {
            InitializeCountries();
            InitializeEmployees();
            

            return base.OnInitializedAsync();
        }


        private void InitializeCountries()
        {
            Countries = new List<Country>
            {
                new Country {CountryId = 1, Name = "Belgium"},
                new Country {CountryId = 2, Name = "Netherlands"},
                new Country {CountryId = 3, Name = "Usa"}
            };
        }

        private void InitializeEmployees()
        {
            var e1 = new Customer
            {
                CountryId = 1,
                BirthDate = new DateTime(1999, 4, 12),
                City = "Amsterdam",
                Email = "Linq@ditislink.nl",
                Id = 1,
                FirstName = "John",
                PhoneNumber = "0633221177",
                LastName = "Berosa",
                Gender = Gender.Male,
                Street = "Kleinestraat 40",
                Zip = "1234"
            };

            Customers = new List<Customer> { e1 };
        }
    }
}
