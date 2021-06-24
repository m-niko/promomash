using System.IO;
using System.Reflection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Promomash.Infrastructure;
using Promomash.Infrastructure.Identity;
using Promomash.WebApp;

namespace Promomash.FunctionalTests
{
    public class TestBase
    {
        protected TestServer TestServer { get; private set; }
        protected ApplicationIdentityDbContext DbContext { get; private set; }
        [OneTimeSetUp]
        public void OnTimeSetup()
        {
            TestServer = CreateServer();
            DbContext = TestServer.Services.GetService<ApplicationIdentityDbContext>();
            SeedData.Initialize(DbContext);
        }
        
        [OneTimeTearDown]
        public void OnTimeTearDown()
        {
            TestServer?.Dispose();
        }

        protected TestServer CreateServer()
        {
            var path = Assembly.GetAssembly(typeof(TestBase))
                .Location;

            var hostBuilder = new WebHostBuilder()
                .UseContentRoot(Path.GetDirectoryName(path))
                .ConfigureAppConfiguration(cb =>
                {
                    cb.AddJsonFile("appsettings.json", optional: false)
                        .AddEnvironmentVariables();
                }).UseStartup<Startup>();

            var testServer = new TestServer(hostBuilder);

            return testServer;
        }
    }
}