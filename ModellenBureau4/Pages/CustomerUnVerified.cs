﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ModellenBureau4.Services;
using ModellenBureau4.Shared;

namespace ModellenBureau4.Pages
{
    public partial class CustomerUnVerified : ComponentBase
    {

        public List<Customer> Customers { get; set; }
        [Inject]
        public ICustomerDataService CustomerDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {

            Customers = (await CustomerDataService.GetAllCustomers()).Where(x => x.Verified == false).ToList();
        }

        protected void NavigateToOverView()
        {
            NavigationManager.NavigateTo("/customeredit");
        }

    }
}