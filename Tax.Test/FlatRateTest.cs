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
    public class FlatRateTest
    {
        protected readonly string baseUrl = "api/V1/TaxResult/";
        private readonly ApiWebApplicationFactory _factory;
        protected readonly HttpClient _client;

        public FlatRateTest()
        {
            _factory = new ApiWebApplicationFactory();
            _client = _factory.CreateClient();

        }
        
        //Test Flat Rate Tax
        [Test]
        public async Task Calculate_FlatRateTax()
        {
            //Arrange
            TaxResultModel taxResultModel = new TaxResultModel
            {
                AnnualIncome = 300000,
                PostalCode = "7000",
            };

            //Act
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, baseUrl);
            request.Content = new StringContent(JsonConvert.SerializeObject(taxResultModel),
                                                Encoding.UTF8,
                                                "application/json");

            var response = await _client.SendAsync(request);

            //Assert
            response.StatusCode.Should().Be(HttpStatusCode.OK);

            string result = await response.Content.ReadAsStringAsync();
            decimal resultValue;
            if (Decimal.TryParse(result, out resultValue))
                resultValue.Should().Be(52500);
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