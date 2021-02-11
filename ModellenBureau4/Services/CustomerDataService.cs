using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ModellenBureau4.Shared;

namespace ModellenBureau4.Services
{
    public class CustomerDataService : ICustomerDataService
    {
        private readonly HttpClient _httpClient;

        public CustomerDataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            var customerJson =
                new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");

            var response = await _httpClient.PostAsync("api/customer", customerJson);

            if (response.IsSuccessStatusCode)
            {
                return await JsonSerializer.DeserializeAsync<Customer>(await response.Content.ReadAsStreamAsync());
            }

            return null;
        }

        public async Task DeleteCustomer(int customerId)
        {
            await _httpClient.DeleteAsync($"api/customer/{customerId}");
        }

        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await JsonSerializer.DeserializeAsync<IEnumerable<Customer>>
                (await _httpClient.GetStreamAsync($"api/customer"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task<Customer> GetCustomerDetails(int customerId)
        {
            return await JsonSerializer.DeserializeAsync<Customer>
                (await _httpClient.GetStreamAsync($"api/customer/{customerId}"), new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
        }

        public async Task UpdateCustomer(Customer customer)
        {
            var customerJson =
                new StringContent(JsonSerializer.Serialize(customer), Encoding.UTF8, "application/json");

            await _httpClient.PutAsync("api/customer", customerJson);
        }
    }
}
