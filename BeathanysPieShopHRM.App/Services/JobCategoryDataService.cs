using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace BeathanysPieShopHRM.App.Services
{
    public class JobCategoryDataService : IJobCategoryDataService
    {
        private readonly HttpClient _httpClient;

        public JobCategoryDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<IEnumerable<JobCategory>> GetJobCategories() =>
             await JsonSerializer.DeserializeAsync<IEnumerable<JobCategory>>
                (await _httpClient.GetStreamAsync($"api/jobcategory"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });


        public async Task<JobCategory> GetJobCategoryById(int id) =>
            await JsonSerializer.DeserializeAsync<JobCategory>
                (await _httpClient.GetStreamAsync($"api/jobcategory/{id}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

    }
}
