using TaskWebApi.Models;

namespace TaskWebApiIntegration.Services
{
    public class OrderServices
    {
        private readonly HttpClient _httpClient;

        public OrderServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Fetch items from the Web API
        public async Task<List<tblItem>> GetOrdersAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7299/api/Items/GetItems");

            if (response.IsSuccessStatusCode)
            {
                var items = await response.Content.ReadFromJsonAsync<List<tblItem>>();
                return items;
            }
            else
            {
                throw new Exception("Failed to fetch items from the API.");
            }
        }
    }
}
