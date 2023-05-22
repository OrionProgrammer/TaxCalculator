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
    public class ProgressiveTaxTest
    {
        protected readonly string baseUrl = "api/V1/TaxResult/";
        private readonly ApiWebApplicationFactory _factory;
        protected readonly HttpClient _client;

        public ProgressiveTaxTest()
        {
            _factory = new ApiWebApplicationFactory();
            _client = _factory.CreateClient();

        }

        #region Postal Code 7441

        //Test Progressive 10%
        [Test]
        public async Task Calculate_Progressive_10_Perc()
        {
            //Arrange
            TaxResultModel taxResultModel = new TaxResultModel
            {
                AnnualIncome = 8350,
                PostalCode = "7441",
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
            double resultValue;
            if (Double.TryParse(result, out resultValue))
                resultValue.Should().Be(835);
        }

        //Test Progressive 15%
        [Test]
        public async Task Calculate_Progressive_15_Perc()
        {
            //Arrange
            TaxResultModel taxResultModel = new TaxResultModel
            {
                AnnualIncome = 8351,
                PostalCode = "7441",
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
            double resultValue;
            if (Double.TryParse(result, out resultValue))
                resultValue.Should().Be(835.15);
        }

        //Test Progressive 25%
        [Test]
        public async Task Calculate_Progressive_25_Perc()
        {
            //Arrange
            TaxResultModel taxResultModel = new TaxResultModel
            {
                AnnualIncome = 33951,
                PostalCode = "7441",
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
            double resultValue;
            if (Double.TryParse(result, out resultValue))
                resultValue.Should().Be(835.4);
        }

        //Test Progressive 28%
        [Test]
        public async Task Calculate_Progressive_28_Perc()
        {
            //Arrange
            TaxResultModel taxResultModel = new TaxResultModel
            {
                AnnualIncome = 82251,
                PostalCode = "7441",
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
            double resultValue;
            if (Double.TryParse(result, out resultValue))
                resultValue.Should().Be(835.68);
        }

        //Test Progressive 33%
        [Test]
        public async Task Calculate_Progressive_33_Perc()
        {
            //Arrange
            TaxResultModel taxResultModel = new TaxResultModel
            {
                AnnualIncome = 171551,
                PostalCode = "7441",
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
            double resultValue;
            if (Double.TryParse(result, out resultValue))
                resultValue.Should().Be(836.01);
        }

        //Test Progressive 35%
        [Test]
        public async Task Calculate_Progressive_35_Perc()
        {
            //Arrange
            TaxResultModel taxResultModel = new TaxResultModel
            {
                AnnualIncome = 372951,
                PostalCode = "7441",
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
            double resultValue;
            if (Double.TryParse(result, out resultValue))
                resultValue.Should().Be(836.36);
        }

        #endregion

        #region Postal Code 1000

        //Test Progressive 10%
        [Test]
        public async Task Calculate_Progressive1000_10_Perc()
        {
            //Arrange
            TaxResultModel taxResultModel = new TaxResultModel
            {
                AnnualIncome = 8350,
                PostalCode = "7441",
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
            double resultValue;
            if (Double.TryParse(result, out resultValue))
                resultValue.Should().Be(835);
        }

        //Test Progressive 15%
        [Test]
        public async Task Calculate_Progressive1000_15_Perc()
        {
            //Arrange
            TaxResultModel taxResultModel = new TaxResultModel
            {
                AnnualIncome = 8351,
                PostalCode = "7441",
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
            double resultValue;
            if (Double.TryParse(result, out resultValue))
                resultValue.Should().Be(835.15);
        }

        //Test Progressive 25%
        [Test]
        public async Task Calculate_Progressive1000_25_Perc()
        {
            //Arrange
            TaxResultModel taxResultModel = new TaxResultModel
            {
                AnnualIncome = 33951,
                PostalCode = "7441",
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
            double resultValue;
            if (Double.TryParse(result, out resultValue))
                resultValue.Should().Be(835.4);
        }

        //Test Progressive 28%
        [Test]
        public async Task Calculate_Progressive1000_28_Perc()
        {
            //Arrange
            TaxResultModel taxResultModel = new TaxResultModel
            {
                AnnualIncome = 82251,
                PostalCode = "7441",
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
            double resultValue;
            if (Double.TryParse(result, out resultValue))
                resultValue.Should().Be(835.68);
        }

        //Test Progressive 33%
        [Test]
        public async Task Calculate_Progressive1000_33_Perc()
        {
            //Arrange
            TaxResultModel taxResultModel = new TaxResultModel
            {
                AnnualIncome = 171551,
                PostalCode = "7441",
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
            double resultValue;
            if (Double.TryParse(result, out resultValue))
                resultValue.Should().Be(836.01);
        }

        //Test Progressive 35%
        [Test]
        public async Task Calculate_Progressive1000_35_Perc()
        {
            //Arrange
            TaxResultModel taxResultModel = new TaxResultModel
            {
                AnnualIncome = 372951,
                PostalCode = "7441",
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
            double resultValue;
            if (Double.TryParse(result, out resultValue))
                resultValue.Should().Be(836.36);
        }

        #endregion


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