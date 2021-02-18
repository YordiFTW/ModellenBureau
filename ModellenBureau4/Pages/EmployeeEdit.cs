using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ModellenBureau4.Services;
using ModellenBureau4.Shared;

namespace ModellenBureau4.Pages
{
    public partial class EmployeeEdit
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }
        [Parameter]
        public string Id { get; set; }
        public Employee Employee { get; set; } = new Employee();

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;



        protected async override Task OnInitializedAsync()
        {
            Saved = false;
            //Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(Id));
            int.TryParse(Id, out var id);

            if (id == 0)
            {
                Employee = new Employee { };
            }
            else
            {
                Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(Id));
            }

        }
        protected async Task HandleValidSubmit()
        {
            Saved = false;

            if (Employee.Id == 0)
            {
                var addedEmployee = await EmployeeDataService.AddEmployee(Employee);
                if (addedEmployee != null)
                {
                    StatusClass = "alert-success";
                    Message = "New employee added successfully.";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Something went wrong adding the new employee. Please try again.";
                    Saved = false;
                }
            }
           
            else
            {
                await EmployeeDataService.UpdateEmployee(Employee);
                StatusClass = "alert-success";
                Message = "Employee updated successfully.";
                Saved = true;
            }
        }

        private void AssignImageUrl(string imgUrl) => Employee.ImageUrl = imgUrl;

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteEmployee()
        {
            await EmployeeDataService.DeleteEmployee(Employee.Id);
            StatusClass = "alert-success";
            Message = "Deleted successfully";
            Saved = true;
        }
        protected void NavigateToOverView()
        {
            NavigationManager.NavigateTo("/employeeoverview");
        }
    }
}
