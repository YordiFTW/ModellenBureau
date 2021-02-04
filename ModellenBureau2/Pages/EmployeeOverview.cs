using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModellenBureau2.Shared;

namespace ModellenBureau2.Pages
{
    public partial class EmployeeOverview
    {

        public IEnumerable<Employee> Employees { get; set; }
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
            var e1 = new Employee
            {
                CountryId = 1,
                BirthDate = new DateTime(1989, 3, 11),
                City = "Brussels",
                Email = "bethany@modellenbureau.com",
                Id = 1,
                FirstName = "Bethany",
                LastName = "Smith",
                Gender = Gender.Female,
                Street = "Grote Markt 1",
                Zip = "1000"
            };

            Employees = new List<Employee> { e1 };
        }
    }
}
