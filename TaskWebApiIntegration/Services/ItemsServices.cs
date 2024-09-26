using TaskWebApi.Models;

namespace TaskWebApiIntegration.Services
{
    public class ItemsServices
    {
        private readonly HttpClient _httpClient;

        public ItemsServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        // Fetch items from the Web API
        public async Task<List<tblItem>> GetItemsAsync()
        {
            // Call the API endpoint, ensure the URL is correct
            var response = await _httpClient.GetAsync("https://localhost:7299/api/Items/GetItems");

            if (response.IsSuccessStatusCode)
            {
                // Deserialize JSON data into List<Item>
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
