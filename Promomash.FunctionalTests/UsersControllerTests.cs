using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using NUnit.Framework;
using Promomash.WebApp.Application.Features.User;

namespace Promomash.FunctionalTests
{
    public class UsersControllerTests : TestBase
    {
        [Test]
        public async Task Should_create()
        {
            var province = await DbContext.Provinces.FirstAsync();
            var registrationData = new Create.Command
            {
                Login = $"{Guid.NewGuid()}@test.com",
                IsAgreeToWorkForFood = true,
                Password = "11q",
                ProvinceId = province.Id
            };
            
            var content = new StringContent(JsonConvert.SerializeObject(registrationData), Encoding.UTF8, "application/json");

            var response = await TestServer.CreateClient().PostAsync("/api/users", content);
            response.EnsureSuccessStatusCode();
        }
    }
}