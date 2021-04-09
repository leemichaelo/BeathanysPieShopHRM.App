using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeathanysPieShopHRM.App.Services
{
    public interface IJobCategoryDataService
    {
        Task<IEnumerable<JobCategory>> GetJobCategories();

        Task<JobCategory> GetJobCategoryById(int id);
    }
}
