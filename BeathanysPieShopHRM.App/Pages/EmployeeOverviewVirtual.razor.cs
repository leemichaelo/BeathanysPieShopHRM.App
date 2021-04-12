using BeathanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web.Virtualization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeathanysPieShopHRM.App.Pages
{
    public partial class EmployeeOverviewVirtual
    {
        private float itemHeight = 50;
        private int totalNumberOfEmployees = 1000;

        public IEnumerable<Employee> Employees { get; set; }

        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }

        protected async override Task OnInitializedAsync() =>
            Employees = (await EmployeeDataService.GetLongEmployeeList()).ToList();

        public async ValueTask<ItemsProviderResult<Employee>> LoadEmployees(ItemsProviderRequest request)
        {
            //assume that we have asked the API the total number in a seperate call

            var numberOfEmployees = Math.Min(request.Count, totalNumberOfEmployees - request.StartIndex);
            var EmployeeListItems = await EmployeeDataService.GetTakeLongEmployeeList(request.StartIndex, numberOfEmployees);

            return new ItemsProviderResult<Employee>(EmployeeListItems, totalNumberOfEmployees);
        }
    }
}
