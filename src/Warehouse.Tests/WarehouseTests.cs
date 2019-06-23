using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Warehouse.API;
using Warehouse.API.Exceptions;
using Warehouse.Entities.DbEntities;
using Xunit;

namespace Warehouse.Tests
{
    public class WarehouseTests : IClassFixture<TestFixture<Startup>>
    {
        private readonly HttpClient _client;

        public WarehouseTests(TestFixture<Startup> fixture)
        {
            _client = fixture?.Client ?? throw new ArgumentNullException(nameof(fixture));
        }

        [Fact]
        public async Task TestGetStockItemsAsync()
        {
            // Arrange
            var request = "/api/StockItem";

            // Act
            var getResponse = await _client.GetAsync(request);

            // Assert
            getResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestGetStockItemAsync()
        {
            // Arrange
            var request = "/api/StockItem/1";

            // Act
            var getResponse = await _client.GetAsync(request);

            // Assert
            getResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostStockItemAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/StockItem",
                Body = new
                {
                    Name = "Бензопила дружба",
                    Brand = "КБ Иванова",
                    Price = 5000
                }
            };

            // Act
            var postResponse = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var stockItem = JsonConvert.DeserializeObject<StockItem>(await postResponse.Content.ReadAsStringAsync());

            var deleteResponse = await _client.DeleteAsync($"/api/StockItem/{stockItem.Id}");

            // Assert
            postResponse.EnsureSuccessStatusCode();
            deleteResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPutStockItemAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/StockItem/1",
                Body = new
                {

                    Name = "Холодильник Юпитер-2",
                    Brand = "Космос",
                    Price = 2000
                }
            };

            // Act
            var putResponse = await _client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            putResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestDeleteStockItemAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/StockItem",
                Body = new
                {
                    Name = "Коктейль молотова",
                    Brand = "Военные прибомбасы",
                    Price = 5000
                }
            };

            // Act
            var postResponse = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var stockItem = JsonConvert.DeserializeObject<StockItem>(await postResponse.Content.ReadAsStringAsync());

            var deleteResponse = await _client.DeleteAsync($"/api/StockItem/{stockItem.Id}");

            // Assert
            postResponse.EnsureSuccessStatusCode();
            deleteResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestDeleteUnExistedStockItemAsync()
        {
            // Act
            var deleteResponse = await _client.DeleteAsync($"/api/StockItem/{int.MaxValue}");
            var errorDetails = JsonConvert.DeserializeObject<ErrorDetails>(await deleteResponse.Content.ReadAsStringAsync());

            // Assert
            Assert.True(deleteResponse.StatusCode == HttpStatusCode.InternalServerError && errorDetails != null);
        }

        [Fact]
        public async Task TestPutUnExistedStockItemAsync()
        {
            // Arrange
            var request = new
            {
                Url = $"/api/StockItem/{int.MaxValue}",
                Body = new
                {

                    Name = "Холодильник Юпитер-2",
                    Brand = "Космос",
                    Price = 2000
                }
            };

            // Act
            var putResponse = await _client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Act
            var errorDetails = JsonConvert.DeserializeObject<ErrorDetails>(await putResponse.Content.ReadAsStringAsync());

            // Assert
            Assert.True(putResponse.StatusCode == HttpStatusCode.InternalServerError && errorDetails != null);
        }

        [Fact]
        public async Task TestGetUnExistedStockItemAsync()
        {
            // Arrange
            var request = $"/api/StockItem/{int.MaxValue}";

            // Act
            var getResponse = await _client.GetAsync(request);

            // Assert
            Assert.True(getResponse.StatusCode == HttpStatusCode.NotFound);
        }

        [Fact]
        public async Task TestPostInvalidNameStockItemAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/StockItem",
                Body = new
                {
                    Name = "xEnwh6aPtenVHKjENaUxojbqMVtecMKZDZ7lo6XsEt3hMX5kuk63Cj4pq32s4xGN530su7sXitfn6FGyngMqNvVX47Mvf2oxQhXMmd9b5vBRDGdZ5GffPAJojjmsErsqeDbrRmTm0KulZNJhiJRvLRUrFnWbSIlc5S7mLvVhyEmVmTVEcwXjifZQVERDyoFjWhNgNpSON",
                    Brand = "КБ Иванова",
                    Price = 5000
                }
            };

            // Act
            var postResponse = await _client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            Assert.True(postResponse.StatusCode == HttpStatusCode.BadRequest);

        }

        [Fact]
        public async Task TestPutInvalidBrandStockItemAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/StockItem/1",
                Body = new
                {

                    Name = "Холодильник Юпитер-2",
                    Brand = "xEnwh6aPtenVHKjENaUxojbqMVtecMKZDZ7lo6XsEt3hMX5kuk63Cj4pq32s4xGN530su7sXitfn6FGyngMqNvVX47Mvf2oxQhXMmd9b5vBRDGdZ5GffPAJojjmsErsqeDbrRmTm0KulZNJhiJRvLRUrFnWbSIlc5S7mLvVhyEmVmTVEcwXjifZQVERDyoFjWhNgNpSON",
                    Price = 2000
                }
            };

            // Act
            var putResponse = await _client.PutAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            // Assert
            Assert.True(putResponse.StatusCode == HttpStatusCode.BadRequest);
        }
    }
}
