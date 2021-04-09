using BeathanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeathanysPieShopHRM.App.Pages
{
    public partial class EmployeeDetail
    {
		[Parameter]
		public string EmployeeId { get; set; }
		public Employee Employee { get; set; } = new Employee();

		[Inject]
		public IEmployeeDataService EmployeeDataService { get; set; }

		protected async override Task OnInitializedAsync() =>
			Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
	}
}
