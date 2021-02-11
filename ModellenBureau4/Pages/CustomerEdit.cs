using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ModellenBureau4.Services;
using ModellenBureau4.Shared;

namespace ModellenBureau4.Pages
{
    public partial class CustomerEdit
    {
        [Inject]
        public ICustomerDataService CustomerDataService { get; set; }
        [Parameter]
        public string Id { get; set; }
        public Customer Customer { get; set; } = new Customer();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;



        protected async override Task OnInitializedAsync()
        {
            Saved = false;
            //Customer = await CustomerDataService.GetCustomerDetails(int.Parse(Id));
            int.TryParse(Id, out var id);

            if (id == 0)
            {
                Customer = new Customer { };
            }
            else
            {
                Customer = await CustomerDataService.GetCustomerDetails(int.Parse(Id));
            }

        }
        protected async Task HandleValidSubmit()
        {
            Saved = false;

            if (Customer.Id == 0)
            {
                var addedCustomer = await CustomerDataService.AddCustomer(Customer);
                if (addedCustomer != null)
                {
                    StatusClass = "alert-success";
                    Message = "New Customer added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new Customer. Please try again.";
                    Saved = false;
                }
            }
           
            else
            {
                await CustomerDataService.UpdateCustomer(Customer);
                StatusClass = "alert-success";
                Message = "Customer updated successfully.";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteCustomer()
        {
            await CustomerDataService.DeleteCustomer(Customer.Id);
            StatusClass = "alert-success";
            Message = "Deleted successfully";
            Saved = true;
        }
        protected void NavigateToOverView()
        {
            NavigationManager.NavigateTo("/Customeroverview");
        }
    }
}
