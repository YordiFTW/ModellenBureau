using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ModellenBureau4.Shared;

namespace ModellenBureau4.Pages
{
    public partial class CustomerOverview
    {

        public IEnumerable<Customer> Customers { get; set; }
        public List<Country> Countries { get; set; }

        protected override Task OnInitializedAsync()
        {



            return base.OnInitializedAsync();
        }


    }
}
