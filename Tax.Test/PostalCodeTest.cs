using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;
using System.Text;
using Tax.Domain;
using Tax.Model;
using Tax.Test.Fixtures;
using Tax.Test.Helpers;

namespace Tax.Test
{
    [Author("Asheen Kamlal", "asheenk@gmail.com")] //shows how to add the Author to a Test Class
    public class PostalCodeTest
    {
        protected readonly string baseUrl = "api/V1/TaxResult/";
        private readonly ApiWebApplicationFactory _factory;
        protected readonly HttpClient _client;

        public PostalCodeTest()
        {
            _factory = new ApiWebApplicationFactory();
            _client = _factory.CreateClient();

        }
        
        //Test incorrect Postl Code 
        [Test]
        [Author("Asheen Kamlal")]  //shows how to add Author specific Test Methods
        public async Task IncorrectPostalCode_Return_400_BadRequest()
        {
            //Arrange
            TaxResultModel taxResultModel = new TaxResultModel
            {
                AnnualIncome = 100000,
                PostalCode = "0000", // incorrect postal code
            };

            //Act
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, baseUrl);
            request.Content = new StringContent(JsonConvert.SerializeObject(taxResultModel),
                                                Encoding.UTF8,
                                                "application/json");

            var response = await _client.SendAsync(request);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        }

        [TearDown]
        public void TestCleanup()
        {
            // Any clean up that needs to happen after each test, can be done here. Just added the method to show my knowledge
        }

        [OneTimeTearDown]
        public void ClassCleanup()
        {
            //This clean up executes after all test cases run.

            _factory.DisposeAsync();
            _client.Dispose();
        }
    }
}