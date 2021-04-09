using BeathanysPieShopHRM.App.Services;
using BethanysPieShopHRM.Shared;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeathanysPieShopHRM.App.Pages
{
    public partial class EmployeeEdit
    {
        [Inject]
        public IEmployeeDataService EmployeeDataService { get; set; }
        [Inject]
        public ICountryDataService CountryDataService { get; set; }
        [Inject]
        public IJobCategoryDataService JobCategoryDataService { get; set; }
        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public string EmployeeId { get; set; }

        public Employee Employee { get; set; } = new Employee();
        public List<Country> Countries { get; set; } = new List<Country>();
        public List<JobCategory> JobCategories { get; set; } = new List<JobCategory>();

        //used to store state of screen
        protected string Message = string.Empty;
        protected string StatusClass = string.Empty;
        protected bool Saved;

        protected async override Task OnInitializedAsync()
        {
            Saved = false;
            Countries = (await CountryDataService.GetAllCountries()).ToList();
            JobCategories = (await JobCategoryDataService.GetJobCategories()).ToList();

            int.TryParse(EmployeeId, out var employeeId);

            if (employeeId == 0) //new employee is being created
            {
                Employee = new Employee { CountryId = 1, JobCategoryId = 1, BirthDate = DateTime.Now, JoinedDate = DateTime.Now };
            }
            else
            {
                Employee = await EmployeeDataService.GetEmployeeDetails(int.Parse(EmployeeId));
            }
        }

        protected async Task HandleValidSubmit()
        {
            Saved = false;

            if (Employee.EmployeeId == 0) //new
            {
                var addedEmployee = await EmployeeDataService.AddEmployee(Employee);

                if (addedEmployee != null)
                {
                    StatusClass = "alert-success";
                    Message = "New employee added successfully!";
                    Saved = true;
                }
                else
                {
                    StatusClass = "alert-danger";
                    Message = "Error when adding new employee. Please try again.";
                    Saved = false;
                }
            }
            else
            {
                await EmployeeDataService.UpdateEmployee(Employee);
                StatusClass = "alert-success";
                Message = "Employee updated successfully!";
                Saved = true;
            }
        }

        protected void HandleInvalidSubmit()
        {
            StatusClass = "alert-danger";
            Message = "There are some validation errors. Please try again.";
        }

        protected async Task DeleteEmployee()
        {
            await EmployeeDataService.DeleteEmployee(Employee.EmployeeId);

            StatusClass = "alert-success";
            Message = "Deleted successfully";

            Saved = true;
        }

        protected void NavigateToOverview() => NavigationManager.NavigateTo("/employeeoverview");
    }
}
