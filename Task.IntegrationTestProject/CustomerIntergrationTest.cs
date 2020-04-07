using Microsoft.AspNetCore.Mvc.Testing;
using System;
using System.Net.Http;
using Task3;
using Task3.Common.Model;
using Xunit;
using ThreadingTask = System.Threading.Tasks;

namespace Task.IntegrationTestProject
{
    public class CustomerIntergrationTest : IClassFixture<WebApplicationFactory<Startup>>
    {
        private WebApplicationFactory<Startup> _factory = null;
        HttpClient _client;
        private const string Url_Path = @"/api/training/addtraining";
        public CustomerIntergrationTest(WebApplicationFactory<Startup> factory)
        {
            this._factory = factory;
            _client = this._factory.CreateClient(new WebApplicationFactoryClientOptions()
            {
                AllowAutoRedirect = false
            });
            _client.DefaultRequestHeaders.Add("ContentType", "application/json");
        }
        [Fact]
        public async ThreadingTask.Task POST_Customer_Success()
        {        
            //Arrange
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(1);
            TrainingModel model = new TrainingModel()
            {
                EndDate = endDate,
                StartDate = startDate,
                TrainingName = "User_" + Guid.NewGuid().GetHashCode()
            };
            //Act
            var response = await _client.PostAsJsonAsync(Url_Path, model).ConfigureAwait(false);

            //Assert
            string responseAsString = await response.Content.ReadAsStringAsync();
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.OK);
            Assert.True(response.IsSuccessStatusCode);
        }

        [Fact]
        public async ThreadingTask.Task POST_Customer_BadRequest_When_Name_Is_Required()
        {
            //Arrange
            TrainingModel model = new TrainingModel {EndDate=DateTime.Now, StartDate=DateTime.Now };
            //Act
            var response = await _client.PostAsJsonAsync(Url_Path, model).ConfigureAwait(false);

            //Assert

            Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
            Assert.False(response.IsSuccessStatusCode);
        }

        [Fact]
        public async ThreadingTask.Task POST_Customer_BadRequest_When_Request_Is_Null()
        {
            //Arrange
            TrainingModel model = null;
            //Act
            var response = await _client.PostAsJsonAsync(Url_Path, model).ConfigureAwait(false);

            //Assert

            Assert.True(response.StatusCode == System.Net.HttpStatusCode.BadRequest);
            Assert.False(response.IsSuccessStatusCode);
        }

        [Fact]
        public async ThreadingTask.Task POST_Customer_InternalServerError_When_Name_Is_Long()
        {
            //Arrange
            var startDate = DateTime.Now;
            var endDate = DateTime.Now.AddDays(1);
            TrainingModel model = new TrainingModel()
            {
                EndDate = endDate,
                StartDate = startDate,
                TrainingName = "User_ToooooooooooooooooooooooooooooooooooooooooooooooLoooooooooooooooooooooooooooooooooooooooooong"
            };
            //Act
            var response = await _client.PostAsJsonAsync(Url_Path, model).ConfigureAwait(false);

            //Assert
            string responseAsString = await response.Content.ReadAsStringAsync();
            Assert.True(response.StatusCode == System.Net.HttpStatusCode.InternalServerError);
            Assert.False(response.IsSuccessStatusCode);
            Assert.Equal("", responseAsString);
        }
    }
}
