using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Promomash.WebApp.Application.Features.Country;

namespace Promomash.FunctionalTests
{
    public class CountriesControllerTests : TestBase
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task Should_return_all_countries()
        {
            var countries = await GetCountriesAsync();
            
            CollectionAssert.IsNotEmpty(countries.Countries);
        }

        [Test]
        public async Task Should_return_provinces_by_country()
        {
            var countriesResponse = await GetCountriesAsync();
            var country = countriesResponse.Countries.First();

            var provinceResponseMessage = await TestServer.CreateClient().GetAsync($"/api/countries/{country.Id}/provinces");
            var provinces =
                JsonConvert.DeserializeObject<GetProvincesByCountryId.Response>(
                    await provinceResponseMessage.Content.ReadAsStringAsync());
            
            CollectionAssert.IsNotEmpty(provinces.Provinces);
        }

        private async Task<GetAll.Response> GetCountriesAsync()
        {
            var response = await TestServer.CreateClient().GetAsync("/api/countries");
            
            response.EnsureSuccessStatusCode();
            
            return JsonConvert.DeserializeObject<GetAll.Response>(await response.Content.ReadAsStringAsync());
        }
    }
}