using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Json;
using EmployeeListApplication;

namespace EmployeeListApplication
{
    public class EmployeeApiClient
    {
        private readonly HttpClient _http;

        public EmployeeApiClient(string baseUrl)
        {
            _http = new HttpClient { BaseAddress = new Uri(baseUrl) };
        }

        public async Task<List<Employee>> GetAllAsync()
            => await _http.GetFromJsonAsync<List<Employee>>("api/employees");

        public async Task<Employee?> GetAsync(int id)
            => await _http.GetFromJsonAsync<Employee>($"api/employees/{id}");

        public async Task<Employee?> CreateAsync(Employee input)
        {
            // Do not send Id for POST — API will generate it
            var payload = new
            {
                firstName = input.FirstName,
                lastName = input.LastName,
                position = input.Position,
                salary = input.Salary
            };

            var resp = await _http.PostAsJsonAsync("api/employees", payload);
            if (!resp.IsSuccessStatusCode) return null;
            return await resp.Content.ReadFromJsonAsync<Employee>();
        }

        public async Task<bool> UpdateAsync(Employee input)
        {
            var resp = await _http.PutAsJsonAsync($"api/employees/{input.Id}", input);
            return resp.IsSuccessStatusCode; // 204 expected
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var resp = await _http.DeleteAsync($"api/employees/{id}");
            return resp.IsSuccessStatusCode; // 204 expected
        }
    }
}

