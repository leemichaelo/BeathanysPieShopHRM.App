using BethanysPieShopHRM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeathanysPieShopHRM.App.Services
{
    public interface ICountryDataService
    {
        Task<IEnumerable<Country>> GetAllCountries();
        Task<Country> GetCountryById(int countryId);
    }
}
