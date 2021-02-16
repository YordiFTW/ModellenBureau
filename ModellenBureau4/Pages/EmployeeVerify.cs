using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ModellenBureau4.Services;
using ModellenBureau4.Shared;

namespace ModellenBureau4.Pages
{
    public partial class EmployeeVerify
    {
        [Parameter]
        public string Id { get; set; }
        public Employee Employee { get; set; } = new Employee();
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }


        protected async override Task OnInitializedAsync()
        {
            Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(Id));

        }

        protected void NavigateToOverView()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }

        protected async Task VerifyEmployee()
        {
            Employee.Verified = true;
            await EmployeeDataService.UpdateEmployee(Employee);
        }
    }
}

 