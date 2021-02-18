using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ModellenBureau4.Services;
using ModellenBureau4.Shared;

namespace ModellenBureau4.Pages
{
    public partial class EmployeeGallery : ComponentBase
    {

        public List<Employee> Employees { get; set; }
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        protected async override Task OnInitializedAsync()
        {

            Employees = (await EmployeeDataService.GetAllEmployees()).Where(x => x.Verified == true).ToList();
        }

        protected void NavigateToOverView()
        {
            NavigationManager.NavigateTo("/employeeedit");
        }

    }
}
