using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Task3.IntegrationTestProject.Helper
{
    /// <summary>
    /// Mimicking Startup class.
    /// </summary>
    public class TestStartup : Startup
    {
        public TestStartup(IConfiguration configuration)
            : base(configuration)
        {
        }

        

        public override void ConfigureServices(IServiceCollection services)
        {
            base.ConfigureServices(services);
            // Add additional service registrations needed in tests
            //services.AddTransient<IDummy, Dummy>();
        }
    }

}
