using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ModellenBureau4.Shared;

namespace ModellenBureau4.Pages
{
    public partial class CustomerDetail
    {
        [Parameter]
        public string Id { get; set; }
        public Customer Customer { get; set; } = new Customer();

        public IEnumerable<Customer> Customers { get; set; }
        public List<Country> Countries { get; set; }

        protected override Task OnInitializedAsync()
        {


            return base.OnInitializedAsync();
        }

    }
}