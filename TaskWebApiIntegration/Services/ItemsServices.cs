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
        public async Task<List<tblOrderMaster>> GetOrdersAsync()
        {
            var response = await _httpClient.GetAsync("https://localhost:7299/api/getorders");

            if (response.IsSuccessStatusCode)
            {
                var items = await response.Content.ReadFromJsonAsync<List<tblOrderMaster>>();
                return items;
            }
            else
            {
                throw new Exception("Failed to fetch items from the API.");
            }
        }

        // Fetch items from the Web API
        public async Task<List<tblItem>> GetItemsAsync()
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

        public async Task<bool> AddItemAsync(tblItem item)
        {
            var response = await _httpClient.PostAsJsonAsync("https://localhost:7299/api/Items/AddItems", item);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                throw new Exception("Failed to add the item via API.");
            }
        }

        public async Task<bool> DeleteItemAsync(int itemId)
        {
            var response = await _httpClient.DeleteAsync($"https://localhost:7299/api/Items/DeleteItems?ItemId={itemId}");

            if (response.IsSuccessStatusCode)
            {
                return true;
            }
            else
            {
                var errorMessage = await response.Content.ReadAsStringAsync();
                throw new Exception($"Failed to delete the item via API. Status Code: {response.StatusCode}, Error: {errorMessage}");
            }
        }

    }
}
