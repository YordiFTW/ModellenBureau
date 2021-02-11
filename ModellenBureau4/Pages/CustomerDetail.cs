using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ModellenBureau4.Services;
using ModellenBureau4.Shared;

namespace ModellenBureau4.Pages
{
    public partial class CustomerDetail
    {
        [Parameter]
        public string Id { get; set; }
        public Customer Customer { get; set; } = new Customer();

        public IEnumerable<Customer> Customers { get; set; }
        [Inject]
        public ICustomerDataService CustomerDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {
            Customer = await CustomerDataService.GetCustomerDetails(int.Parse(Id));

        }

        protected void NavigateToOverView()
        {
            NavigationManager.NavigateTo("/customeroverview");
        }

    }
}