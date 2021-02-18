using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components;
using ModellenBureau4.Services;
using ModellenBureau4.Shared;

namespace ModellenBureau4.Pages
{
    public partial class Index : ComponentBase
    {
        public IEnumerable<Employee> Employees2 { get; set; }
        public List<Employee> Employees { get; set; }
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        protected async override Task OnInitializedAsync()
        {

            Employees2 = (await EmployeeDataService.GetAllEmployees()).Where(x => x.Verified == true).ToList();

        }
    }
}
