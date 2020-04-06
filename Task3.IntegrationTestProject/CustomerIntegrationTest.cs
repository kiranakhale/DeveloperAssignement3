using System;
using System.Net;
using System.Threading.Tasks;
using Task3.IntegrationTestProject.Helper;
using Xunit;

namespace Task3.IntegrationTestProject
{
    public class CustomerIntegrationTest
    {

        private readonly HttpClientHelper _httpClientHelper;

        public CustomerIntegrationTest()
        {

        }
        [Fact]
        public async Task Test_AddCustomer()
        {
            //try
            //{
            //    var client = new TestClientProvider().Client;
            //    var response = await client.GetAsync("/api/Training/create");

            //    response.EnsureSuccessStatusCode();
            //    Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            //}
            //catch (Exception e)
            //{

            //}
        }
    }
}
